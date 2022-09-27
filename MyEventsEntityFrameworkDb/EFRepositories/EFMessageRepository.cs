using Microsoft.Extensions.Logging;
using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;
using MyEventsEntityFrameworkDb.Entities.Pagination;
using System.Linq;

namespace MyEventsEntityFrameworkDb.EFRepositories;

public class EFMessageRepository : EFGenericRepository<Message>, IEFMessageRepository
{
    public EFMessageRepository(MyEventsDbContext databaseContext)
        : base(databaseContext)
    {
    }

    public override Task<Message> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList<Message>> GetPaginatedMessagesAsync(ShowMessageParameters showMessageParameters)
    {
        var source = table
            .Join(databaseContext.Users,
                m => m.UserId,
                u => u.Id,
                (m, u) => new
                {
                    m, u
                })
            .Join(databaseContext.Events,
                mm => mm.m.EventId,
                e => e.Id,
                (mm, e) => new Message
                {
                    Id = mm.m.Id,
                    UserId = mm.m.UserId,
                    EventId = mm.m.EventId,
                    Message1 = mm.m.Message1,
                    User = mm.u,
                    Event = e
                });

        if (showMessageParameters.UserId != null)
            source = source.Where(m => m.UserId == showMessageParameters.UserId);
        if (showMessageParameters.EventId != null)
            source = source.Where(m => m.EventId == showMessageParameters.EventId);

        var paginated_event_data = await PagedList<Message>.ToPagedListAsync(
                source,
                showMessageParameters.PageNumber,
                showMessageParameters.PageSize);

        return paginated_event_data;
    }
}
