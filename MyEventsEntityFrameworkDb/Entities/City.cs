using System;
using System.Collections.Generic;

namespace MyEventsEntityFrameworkDb.Entities
{
    public partial class City
    {
        public City()
        {
            Countries = new HashSet<Country>();
            Events = new HashSet<Event>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
