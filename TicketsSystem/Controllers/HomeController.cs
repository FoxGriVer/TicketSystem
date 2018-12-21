using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketsSystem.Models;
using TicketsSystem.Repository;
using TicketsSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TicketsSystem.Controllers
{
    public class HomeController : Controller
    {
        private IRepository mySqlRepository; /*= MySqlRepository.GetInstance();*/        

        public HomeController(IRepository _mySqlRepository)
        {
            mySqlRepository = _mySqlRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            using (MySqlContext cont = new MySqlContext())
            {
                List<Test> tests = cont.Tests.FromSql("SELECT * FROM  `Orders` INNER JOIN Users ON Users.UserId = Orders.OrderId WHERE  `OrderId` = 1").ToList();
                //List<User> users = cont.Users.FromSql("SELECT * FROM `Users` WHERE 1").ToList();
            }
            //List<User> users = mySqlRepository.GetUserCRUD().GetAll().ToList();
            
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
