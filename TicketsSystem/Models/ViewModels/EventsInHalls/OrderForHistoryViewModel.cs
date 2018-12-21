using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsSystem.Models.ViewModels.EventsInHalls
{
    public class OrderForHistoryViewModel
    {
        [Key]
        public int OrderId { get; set; }

        [Column("DateOrdered")]
        public DateTime DateOrdered { get; set; }                

        [Column("Row")]
        public int Row { get; set; }

        [Column("Coll")]
        public int Coll { get; set; }

        [Column("Building")]
        public string Building { get; set; }

        [Column("Hall")]
        public string Hall { get; set; }

        [Column("EventPrice")]
        public int EventPrice { get; set; }

        [Column("DateTimeEvent")]
        public DateTime DateTimeEvent { get; set; }

        [Column("EventName")]
        public string EventName { get; set; }
    }
}
