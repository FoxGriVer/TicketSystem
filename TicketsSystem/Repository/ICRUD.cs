using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsSystem.Models.Entities;

namespace TicketsSystem.Repository
{
    public interface ICRUD<T> where T: BaseEntity
    {
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        T GetByID(int id);
        IEnumerable<T> GetAll();
    }
}
