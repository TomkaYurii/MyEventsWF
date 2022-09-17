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
        var my_event =  await table.Include(ev => ev.User)
                                 .Include(ev => ev.Gallery)
                                     .ThenInclude(gal => gal.Images)
                                 .SingleOrDefaultAsync(ev => ev.Id == id);
        return my_event ?? throw new EntityNotFoundException("NOT FOUND");
    }

    public async Task<PagedList<Event>> GetPaginationEvents(ShowEventParameters showEventParameters)
    {
        IQueryable<Event> source = table.Include(ev => ev.User)
                                 .Include(ev => ev.Gallery)
                                     .ThenInclude(gal => gal.Images);
        return PagedList<Event>.ToPagedList(
                source,
                showEventParameters.PageNumber,
                showEventParameters.PageSize);
    }
}
