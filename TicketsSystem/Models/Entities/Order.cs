using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicketsSystem.Models.Entities
{
    public class Order: BaseEntity
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int FK_UserId { get; set; }
    }
}
