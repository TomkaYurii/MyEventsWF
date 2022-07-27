using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories;

public class EFImageRepository : EFGenericRepository<Image>, IEFImageRepository
{
    public EFImageRepository(MyEventsDbContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Image>> GetAllImagesByGalleryIdAsync(int id)
    {
        IEnumerable<Image> results = databaseContext.Images.Where(i => i.GalleryId == id);
        if (results == null)
            throw new Exception($"Images with this id of Gallery [{id}] could not be found.");
        return results;
    }

    public override Task<Image> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
