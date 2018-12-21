using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsSystem.Repository;
using TicketsSystem.Models.Entities;

namespace TicketsSystem.Repository
{
    public interface IRepository
    {
        ICRUD<User> GetUserCRUD();
        ICRUD<Event> GetEventCRUD();
    }
}
