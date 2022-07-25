using System;
using System.Collections.Generic;

namespace MyEventsEntityFrameworkDb.Entities
{
    public partial class Category
    {
        public Category()
        {
            CategoriesEvents = new HashSet<CategoriesEvent>();
        }

        public int Id { get; set; }
        public int Name { get; set; }

        public virtual ICollection<CategoriesEvent> CategoriesEvents { get; set; }
    }
}
