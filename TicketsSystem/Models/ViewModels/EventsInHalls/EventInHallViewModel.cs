using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsSystem.Models.ViewModels.EventsInHalls
{
    public class EventInHallViewModel
    {
        [Key]
        public int EventInHallId { get; set; }

        [Required]
        [Column("EventId")]
        public int EventId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [Column("EventName")]
        public string EventName { get; set; }

        [Required]
        public string Poster { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Column("HallName")]
        public string HallName { get; set; }

        [Required]
        [Column("BuildingName")]
        public string BuildingName { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
