using System;
using System.Collections.Generic;

namespace MyEventsEntityFrameworkDb.Entities
{
    public partial class Gallery
    {
        public Gallery()
        {
            Events = new HashSet<Event>();
            Images = new HashSet<Image>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
