using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsAdoNetDB.Entities
{
    public  class Event : BaseEntity
    {
        public string Name { get; set; }
        public int User_id { get; set; }
        public int Country_id { get; set; }
        public int City_id { get; set; }
        public int Gallery_id { get; set; }
    }
}
