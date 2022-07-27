using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories;

public class EFEventRepository : EFGenericRepository<Event>, IEFEventRepository
{
    public EFEventRepository(MyEventsDbContext databaseContext)
        : base(databaseContext)
    {
    }

    public override Task<Event> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Event>> GetTop10EventsAsync()
    {
        return await Task.Run(() => databaseContext.Events
            .OrderByDescending(X => X.DateOfEvent)
            .Take(10));
    }
}
