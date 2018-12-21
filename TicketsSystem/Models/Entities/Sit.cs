using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TicketsSystem.Models.Entities
{
    public class Sit: BaseEntity
    {
        [Key]
        public int SitId { get; set; }

        [Required]
        public int Row { get; set; }

        [Required]
        public int Coll { get; set; }
    }
}
