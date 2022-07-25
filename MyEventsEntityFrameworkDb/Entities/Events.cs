using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsEntityFrameworkDb.Entities
{
    internal class Events
    {
        public int id { get; set; }
        public string name { get; set; }
        public int user_id { get; set; }
        public Users user { get; set; }
        public int country_id { get; set; }
        public Countries Country { get; set; }
        public int city_id { get; set; }
        public Cities City { get; set; }
        public int gallery_id { get; set; }
        public Galleries Gallery { get; set; }
        public TimeOnly time_of_event { get; set; }
        public DateOnly date_of_event { get; set; }
        public string address { get; set; }
        public int acceptable_age { get; set; }
        public float cost_of_visit { get; set; }
    }
}
