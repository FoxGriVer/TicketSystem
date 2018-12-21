using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsSystem.Models.Entities;

namespace TicketsSystem.Repository.MySql.MySqlCRUD
{
    public class UserRepository : ICRUD<User>
    {
        MySqlContext context = new MySqlContext();

        public void Add(User user)
        {            
            context.Add(user);
            context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = context.Users.ToList();
            return users;
        }

        public User GetByID(int id)
        {
            User user = context.Users.FirstOrDefault(x => x.UserId == id);
            return user;
        }

        public User GetByEmail(string email)
        {
            User user = context.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }

        public User TryAuthinticateUser(string email, string password)
        {
            User user = context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            return user;
        }

        public void Remove(int id)
        {
            User user = context.Users.FirstOrDefault(x => x.UserId == id);
            if(user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public void Update(User item)
        {
            User user = context.Users.FirstOrDefault(x => x.UserId == item.UserId);
            if (user != null)
            {
                var query = "UPDATE Users " +
                            "SET FirstName = {0}, SecondName = {1}, Phone = {2}, CardNumber ={3}, " +
                            "Email = {4}, Password = {5} " +
                            "WHERE UserId = {6}";
                context.Database.ExecuteSqlCommand(query, item.FirstName, item.SecondName, item.Phone, item.CardNumber,
                    item.Email, item.Password, item.UserId);
                context.SaveChanges();
            }
        }
    }
}
