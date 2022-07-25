using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(MyEventsDbContext databaseContext)
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
}
