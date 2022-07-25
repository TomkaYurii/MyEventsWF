using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsEntityFrameworkDb.Entities
{
    internal class Messages
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public Users user { get; set; }
        public int event_id { get; set; }
        public Events events { get; set; } 
        public string message { get; set; }
    }
}
