using System;
using System.Collections.Generic;

namespace MyEventsEntityFrameworkDb.Entities
{
    public partial class Country
    {
        public Country()
        {
            Events = new HashSet<Event>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? CityId { get; set; }

        public virtual City? City { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
