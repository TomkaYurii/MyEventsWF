using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsAdoNetDB.Repositories.Interfaces
{
    public  interface IImageRepository : IGenericRepository<Image>
    {
        Task<IEnumerable<Image>> GetAllImagesByGalleryIdAsync(int id);
    }
}
