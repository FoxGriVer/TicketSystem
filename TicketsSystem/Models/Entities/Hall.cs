using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicketsSystem.Models.Entities
{
    public class Hall: BaseEntity
    {
        [Key]
        public int HallId { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int FK_BuildingId { get; set; }
    }
}
