using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsSystem.Models.Entities;
using TicketsSystem.Models.ViewModels.EventsInHalls;

namespace TicketsSystem.Repository.MySql.MySqlCRUD
{
    public class EventRepository: ICRUD<Event>
    {
        MySqlContext context = new MySqlContext();

        public void Add(Event item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            List<Event> events = context.Events.ToList();
            return events;
        }

        public IEnumerable<EventInHallViewModel> GetAllEventsWithAllInfo()
        {
            string sqlQuery = @"SELECT EventInHalls.EventInHallId AS 'EventInHallId', EventInHalls.DateTime, EventInHalls.Price, Events.EventId AS 'EventId', Events.Name AS 'EventName', Events.Description, Events.Poster,
                                Halls.Name AS 'HallName', Buildings.Name AS 'BuildingName', Buildings.Address
                                FROM EventInHalls
                                INNER JOIN Events ON Events.EventId = EventInHalls.FK_EventId
                                INNER JOIN Halls ON Halls.HallId = EventInHalls.FK_HallId
                                INNER JOIN Buildings ON Buildings.BuildingId = Halls.FK_BuildingId";
            var events = context.EventInHallViewModels.FromSql(sqlQuery).ToList();
            return events;
        }

        public Event GetByID(int id)
        {
            Event anEvent = context.Events.FirstOrDefault(x => x.EventId == id);
            return anEvent;
        }
       
        public IEnumerable<EventInHallViewModel> GetEventWithAllInfoAndSessionsById(int id)
        {
            string sqlQuery = @"SELECT EventInHalls.EventInHallId AS 'EventInHallId', EventInHalls.DateTime, EventInHalls.Price, Events.EventId AS 'EventId', Events.Name AS 'EventName', Events.Description, Events.Poster,
                                Halls.Name AS 'HallName', Buildings.Name AS 'BuildingName', Buildings.Address
                                FROM EventInHalls
                                INNER JOIN Events ON Events.EventId = EventInHalls.FK_EventId
                                INNER JOIN Halls ON Halls.HallId = EventInHalls.FK_HallId
                                INNER JOIN Buildings ON Buildings.BuildingId = Halls.FK_BuildingId
                                WHERE Events.EventId = {0}";

            var idInQuery = id;
            IEnumerable<EventInHallViewModel> anEvent = context.EventInHallViewModels.FromSql(sqlQuery, idInQuery);
            return anEvent;
        }

        public void AddTicket(TicketsEventsViewModel ticket)
        {
            
            Sit sit = context.Sits.FirstOrDefault(x => (x.Row == ticket.Row) & (x.Coll == ticket.Coll) );

            Order order = new Order()
            {
                Date = ticket.DateTime,
                FK_UserId = ticket.UserId
            };
            context.Orders.Add(order);
            context.SaveChanges();

            EventInHallTakenSit eventInHallTakenSit = new EventInHallTakenSit()
            {
                FK_EventInHallId = ticket.EventInHallId,
                FK_OrderId = order.OrderId,
                FK_SitId = sit.SitId
            };
            context.EventInHallTakenSits.Add(eventInHallTakenSit);
            context.SaveChanges();
        }

        public IEnumerable<OrderForHistoryViewModel> GetTicketsHistory(int userId)
        {
            string sqlQuery = @"SELECT Orders.OrderId, Orders.Date AS 'DateOrdered', Sits.Row AS 'Row', Sits.Coll AS 'Coll',
                                Buildings.Name AS 'Building', Halls.Name AS 'Hall', EventInHalls.Price AS 'EventPrice',
                                EventInHalls.DateTime AS 'DateTimeEvent', Events.Name AS 'EventName'
                                FROM Orders  
                                INNER JOIN EventInHallTakenSits ON EventInHallTakenSits.FK_OrderId = Orders.OrderId
                                INNER JOIN Sits ON EventInHallTakenSits.FK_SitId = Sits.SitId
                                INNER JOIN EventInHalls ON EventInHalls.EventInHallId = EventInHallTakenSits.FK_EventInHallId
                                INNER JOIN Events ON EventInHalls.FK_EventId = Events.EventId
                                INNER JOIN Halls ON Halls.HallId = EventInHalls.FK_HallId
                                INNER JOIN Buildings ON Buildings.BuildingId = Halls.FK_BuildingId
                                WHERE Orders.FK_UserId LIKE {0}";
            var idInQuery = "%" + userId + "%";
            IEnumerable<OrderForHistoryViewModel> orders = context.OrderForHistoryViewModels.FromSql(sqlQuery, idInQuery);
            return orders;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Event item)
        {
            throw new NotImplementedException();
        }
    }
}
