using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsEntityFrameworkDb.Entities
{
    internal class Countries
    {
        public int id { get; set; }
        public string name { get; set; }
        public int city_id { get; set; }
        public Cities City { get; set; }
    }
}
