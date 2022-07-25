using System;
using System.Collections.Generic;

namespace MyEventsEntityFrameworkDb.Entities
{
    public partial class Event
    {
        public Event()
        {
            CategoriesEvents = new HashSet<CategoriesEvent>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? UserId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? GalleryId { get; set; }
        public TimeSpan? TimeOfEvent { get; set; }
        public DateTime? DateOfEvent { get; set; }
        public string? Address { get; set; }
        public int? AcceptableAge { get; set; }
        public double? CostOfVisit { get; set; }

        public virtual City? City { get; set; }
        public virtual Country? Country { get; set; }
        public virtual Gallery? Gallery { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<CategoriesEvent> CategoriesEvents { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
