using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsEntityFrameworkDb.Entities
{
    internal class Images
    {
        public int id { get; set; }
        public string name { get; set; }
        public int gallery_id { get; set; }
        public Galleries gallery { get; set; }
        public int user_id { get; set; }
        public Users user { get; set; }
    }
}
