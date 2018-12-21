using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsSystem.Repository;
using TicketsSystem.Models.ViewModels.EventsInHalls;
using TicketsSystem.Repository.MySql.MySqlCRUD;
using Microsoft.AspNetCore.Authorization;
using TicketsSystem.Models.Entities;

namespace TicketsSystem.WebApi
{
    [Produces("application/json")]
    [Route("api/Ticket")]
    public class TicketController : Controller
    {

        private IRepository mySqlRepository;
        private EventRepository eventRepository;
        private UserRepository userRepository;

        public TicketController(IRepository _mySqlRepository)
        {
            mySqlRepository = _mySqlRepository;
            eventRepository = (EventRepository)this.mySqlRepository.GetEventCRUD();
            userRepository = (UserRepository)this.mySqlRepository.GetUserCRUD();
        }

        [Route("buyTickets")]
        [HttpPost]
        [Authorize]
        public IActionResult BuyTicket([FromBody] TicketsEventsViewModel ticket)
        {
            eventRepository.AddTicket(ticket);
            return Ok();
        }


        [Route("getAllTicketsByUser")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllTicketsByUser()
        {
            var email = User.Identity.Name;
            User user = userRepository.GetByEmail(email);
            if(user == null)
            {
                return BadRequest();
            }
            var orders = eventRepository.GetTicketsHistory(user.UserId);
            return Ok(orders);
        }
    }
}