using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using TicketsSystem.Models.Entities;
using TicketsSystem.Models;
using TicketsSystem.Models.ViewModels.EventsInHalls;

namespace TicketsSystem.Repository
{
    public class MySqlContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventInHall> EventInHalls { get; set; }
        public DbSet<EventInHallTakenSit> EventInHallTakenSits { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Sit> Sits { get; set; }

        public DbSet<Test> Tests { get; set; }
        public DbSet<EventInHallViewModel> EventInHallViewModels { get; set; }
        public DbSet<OrderForHistoryViewModel> OrderForHistoryViewModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=31.31.196.86;UserId=u0600073_pavel;Password=dotcomuser;database=u0600073_ticketsystem; Charset=utf8;");
        }
    }
}
