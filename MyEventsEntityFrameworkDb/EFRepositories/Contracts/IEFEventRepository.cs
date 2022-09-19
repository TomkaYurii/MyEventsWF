using MyEventsEntityFrameworkDb.Entities;
using MyEventsEntityFrameworkDb.Entities.pagination;

namespace MyEventsEntityFrameworkDb.EFRepositories.Contracts;

public interface IEFEventRepository : IEFGenericRepository<Event>
{
    Task<PagedList<Event>> GetPaginatedEventsAsync(EventsParametrs eventsParametrs);
}