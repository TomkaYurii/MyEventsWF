using MyEventsEntityFrameworkDb.Entities;
using MyEventsEntityFrameworkDb.Entities.Pagination;

namespace MyEventsEntityFrameworkDb.EFRepositories.Contracts;

public interface IEFMessageRepository : IEFGenericRepository<Message>
{
    Task<PagedList<Message>> GetPaginatedMessagesAsync(ShowMessageParameters showMessageParameters);
}
