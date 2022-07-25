using System;
using System.Collections.Generic;

namespace MyEventsEntityFrameworkDb.Entities
{
    public partial class User
    {
        public User()
        {
            Events = new HashSet<Event>();
            Images = new HashSet<Image>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }

        public virtual City? City { get; set; }
        public virtual Country? Country { get; set; }
        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
