using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories.Contracts;

public interface IEFImageRepository : IEFGenericRepository<Image>
{
    Task<IEnumerable<Image>> GetAllImagesByGalleryIdAsync(int id);
}
