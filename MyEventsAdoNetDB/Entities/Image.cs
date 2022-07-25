using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsAdoNetDB.Entities
{
    public  class Image : BaseEntity
    {
        public string Name { get; set; }
        public int? Gallery_id { get; set; }
        public int? User_id { get; set; }       
    }
}
