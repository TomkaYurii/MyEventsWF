using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories;

public class EFGalleryRepository : EFGenericRepository<Gallery>, IEFGalleryRepository
{
    public EFGalleryRepository(MyEventsDbContext databaseContext)
        : base(databaseContext)
    {
    }

    public override Task<Gallery> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
