using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsEntityFrameworkDb.Entities
{
    internal class Users
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int role_id { get; set; }
        public Roles role { get; set; }
        public int country_id { get; set; }
        public Countries country { get; set; }
        public int city_id { get; set; }
        public Cities city { get; set; }
    }
}
