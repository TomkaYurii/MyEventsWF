using Microsoft.EntityFrameworkCore;
using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;
using MyEventsEntityFrameworkDb.Entities.Pagination;
using MyEventsEntityFrameworkDb.Exceptions;

namespace MyEventsEntityFrameworkDb.EFRepositories;
public class EFEventRepository : EFGenericRepository<Event>, IEFEventRepository
{
    public EFEventRepository(MyEventsDbContext databaseContext)
        : base(databaseContext)
    {
    }
    public override async Task<Event> GetCompleteEntityAsync(int id)
    {
        var my_event = await table.Include(ev => ev.User)
                                 .Include(ev => ev.Gallery)
                                     .ThenInclude(gal => gal.Images)
                                 .SingleOrDefaultAsync(ev => ev.Id == id);
        return my_event ?? throw new EntityNotFoundException("NOT FOUND");
    }

    public async Task<PagedList<Event>> GetPaginatedEventsAsync(ShowEventParameters showEventParameters)
    {
        // коли забираємо зв'язані дані з декількох таблиць
        // EagerLoading не відпрацює через циклічність звязків
        var source = table.Join(databaseContext.Users,
            e => e.UserId,
            u => u.Id,
            (e, u) => new Event
            {
                Id = e.Id,
                Name = e.Name,
                TimeOfEvent = e.TimeOfEvent,
                DateOfEvent = e.DateOfEvent,
                Address = e.Address,
                User = u
            });

        // прокидуємо отримані результати на пагінування
        var paginated_event_data = await PagedList<Event>.ToPagedListAsync(
                source,
                showEventParameters.PageNumber,
                showEventParameters.PageSize);

        // повертаємо пропагіновані дані
        return paginated_event_data;
    }
}