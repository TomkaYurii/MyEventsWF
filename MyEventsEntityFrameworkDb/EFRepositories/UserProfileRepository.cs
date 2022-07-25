using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories
{
    public class UserProfileRepository : GenericRepository<User>, IUserProfileRepository
    {
        public UserProfileRepository(MyEventsDbContext databaseContext)
            : base(databaseContext)
        {
        }

        public override Task<User> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
