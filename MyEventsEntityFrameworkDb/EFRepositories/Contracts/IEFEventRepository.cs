using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories.Contracts;

public interface IEFEventRepository : IEFGenericRepository<Event>
{
    Task<IEnumerable<Event>> GetTop10EventsAsync();
}
