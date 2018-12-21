using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsSystem.Models.Entities;
using TicketsSystem.Models.ViewModels.EventsInHalls;
using TicketsSystem.Repository;
using TicketsSystem.Repository.MySql.MySqlCRUD;

namespace TicketsSystem.WebApi
{
    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : Controller
    {

        private IRepository mySqlRepository;
        private EventRepository eventRepository;

        public EventController(IRepository _mySqlRepository)
        {
            mySqlRepository = _mySqlRepository;
            eventRepository = (EventRepository)this.mySqlRepository.GetEventCRUD();
        }

        [Route("getAllEvents")]
        [HttpGet]
        public IEnumerable<Event> GetAllEvents()
        {
            return eventRepository.GetAll().ToList();
        }

        [Route("getAllEventsWithAllInfo")]
        [HttpGet]
        public IEnumerable<EventInHallViewModel> GetAllEventsWithAllInfo()
        {
            List<EventInHallViewModel> events = eventRepository.GetAllEventsWithAllInfo().ToList();
            return events;
        }

        [HttpGet("{id}")]
        public IEnumerable<EventInHallViewModel> GetEvent(int id)
        {
            return eventRepository.GetEventWithAllInfoAndSessionsById(id);
        }

    }
}