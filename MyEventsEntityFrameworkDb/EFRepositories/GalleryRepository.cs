using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories
{
    public class GalleryRepository : GenericRepository<Gallery>, IGalleryRepository
    {
        public GalleryRepository(MyEventsDbContext databaseContext)
            : base(databaseContext)
        {
        }

        public override Task<Gallery> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
