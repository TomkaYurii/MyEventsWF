using System;
using System.Collections.Generic;

namespace MyEventsEntityFrameworkDb.Entities
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
