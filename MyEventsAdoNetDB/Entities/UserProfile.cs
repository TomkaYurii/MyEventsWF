using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsAdoNetDB.Entities
{
    public  class UserProfile : BaseEntity
    {
        public string First_Name { get; set; }
        public string Second_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role_id { get; set; }
        public int Country_id { get; set; }
        public int City_id { get; set; }
    }
}
