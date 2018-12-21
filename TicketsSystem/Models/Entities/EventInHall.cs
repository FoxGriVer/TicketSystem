using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicketsSystem.Models.Entities
{
    public class EventInHall: BaseEntity
    {
        [Key]
        public int EventInHallId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int Price { get; set; }

        public int FK_EventId { get; set; }

        public int FK_HallId { get; set; }
    }
}
