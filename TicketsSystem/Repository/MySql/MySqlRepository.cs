using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsSystem.Repository;
using TicketsSystem.Models.Entities;
using TicketsSystem.Repository.MySql.MySqlCRUD;

namespace TicketsSystem.Repository
{
    public class MySqlRepository: IRepository
    {
        //разкоментировать и заприватить конструктор, если охото сделать синглтон

        //private static MySqlRepository instance;
        //private static object obj = new object();

        private UserRepository UserRepository { get; set; }
        private EventRepository EventRepository { get; set; }

        public ICRUD<User> GetUserCRUD()
        {
            return UserRepository;
        }

        public ICRUD<Event> GetEventCRUD()
        {
            return EventRepository;
        }

        public MySqlRepository()
        {
            UserRepository = new UserRepository();
            EventRepository = new EventRepository();
        }

        //public static MySqlRepository GetInstance()
        //{
        //    lock(obj)
        //    {
        //        if(instance == null)
        //        {
        //            instance = new MySqlRepository();
        //        }
        //        return instance;
        //    }
        //}

        
    }
}
