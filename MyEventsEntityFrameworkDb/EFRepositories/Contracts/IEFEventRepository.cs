using MyEventsEntityFrameworkDb.Entities;
using MyEventsEntityFrameworkDb.Entities.Pagination;

namespace MyEventsEntityFrameworkDb.EFRepositories.Contracts;

public interface IEFEventRepository : IEFGenericRepository<Event>
{
    Task<PagedList<Event>> GetPaginatedEventsAsync(ShowEventParameters showEventParameters);
    Task<IEnumerable<Event>> GetEventsByName(string name);
}