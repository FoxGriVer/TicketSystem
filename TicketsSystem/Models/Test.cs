using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicketsSystem.Models
{
    public class Test
    {
        public int UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int FK_UserId { get; set; }
    }
}
