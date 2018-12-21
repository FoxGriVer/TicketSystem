using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsSystem.Models.ViewModels.EventsInHalls
{
    public class TicketsEventsViewModel
    {
        [Key]
        public int EventInHallTakenSitsId { get; set; }        

        [Required]
        [Column("EventInHallId")]
        public int EventInHallId { get; set; }

        [Required]
        [Column("HallId")]
        public int HallId { get; set; }

        [Column("SitId")]
        public int SitId { get; set; }

        [Column("OrderId")]
        public int OrderId { get; set; }

        public int Row { get; set; }

        public int Coll { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
