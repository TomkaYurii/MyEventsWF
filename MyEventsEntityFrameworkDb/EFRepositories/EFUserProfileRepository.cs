using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories;

public class EFUserProfileRepository : EFGenericRepository<User>, IEFUserProfileRepository
{
    public EFUserProfileRepository(MyEventsDbContext databaseContext)
        : base(databaseContext)
    {
    }

    public override Task<User> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
