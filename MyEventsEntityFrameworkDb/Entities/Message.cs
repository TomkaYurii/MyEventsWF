using System;
using System.Collections.Generic;

namespace MyEventsEntityFrameworkDb.Entities
{
    public partial class Message
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? EventId { get; set; }
        public string? Message1 { get; set; }

        public virtual Event? Event { get; set; }
        public virtual User? User { get; set; }
    }
}
