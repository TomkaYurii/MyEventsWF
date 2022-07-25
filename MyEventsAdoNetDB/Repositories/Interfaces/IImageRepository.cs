using MyEventsAdoNetDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsAdoNetDB.Repositories.Interfaces
{
    public  interface IImageRepository : IGenericRepository<Image>
    {
        Task<IEnumerable<Image>> GetAllImagesByGalleryIdAsync(int id);
    }
}
