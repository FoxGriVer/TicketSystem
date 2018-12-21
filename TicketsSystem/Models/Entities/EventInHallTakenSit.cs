using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicketsSystem.Models.Entities
{
    public class EventInHallTakenSit: BaseEntity
    {
        [Key]
        public int EventInHallTakenSitId { get; set; }

        public int FK_SitId { get; set; }

        public int FK_EventInHallId { get; set; }

        public int FK_OrderId { get; set; }
    }
}
