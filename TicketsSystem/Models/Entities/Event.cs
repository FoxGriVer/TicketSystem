using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicketsSystem.Models.Entities
{
    public class Event: BaseEntity
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Poster { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
