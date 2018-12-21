using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsSystem.Models.Entities;
using TicketsSystem.Repository;
using TicketsSystem.Repository.MySql.MySqlCRUD;

namespace TicketsSystem.WebApi
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {

        private IRepository mySqlRepository;
        private UserRepository userRepository;

        public UserController(IRepository _mySqlRepository)
        {
            mySqlRepository = _mySqlRepository;
            userRepository = (UserRepository)this.mySqlRepository.GetUserCRUD();
        }

        [Route("getPersonalInformation")]
        [HttpGet]
        [Authorize]
        public IActionResult GetPersonalInformation()
        {
            var identity = User.Identity.Name;
            var user = userRepository.GetByEmail(identity);
            return Ok(user);
        }

        [Route("updatePersonalInfo")]
        [HttpPut]
        [Authorize]
        public IActionResult UpdatePersonalInformation([FromBody]User user)
        {
            userRepository.Update(user);
            return Ok(user);
        }

        [Route("createUser")]
        [HttpPost]
        public IActionResult Register([FromBody]User user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userRepository.Add(user);
            return Ok();
        }

    }
}