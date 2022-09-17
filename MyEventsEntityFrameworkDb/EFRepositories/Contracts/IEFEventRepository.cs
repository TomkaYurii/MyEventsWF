using MyEventsEntityFrameworkDb.Entities;
using MyEventsEntityFrameworkDb.Entities.Pagination;

namespace MyEventsEntityFrameworkDb.EFRepositories.Contracts;

public interface IEFEventRepository : IEFGenericRepository<Event>
{
    Task<PagedList<Event>> GetPaginationEvents(ShowEventParameters showEventParameters);
}