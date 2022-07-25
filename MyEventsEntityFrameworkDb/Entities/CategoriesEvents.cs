using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsEntityFrameworkDb.Entities
{
    internal class CategoriesEvents
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public Categories Category { get; set; }
        public int event_id { get; set; }
        public Events events { get; set; }
    }
}
