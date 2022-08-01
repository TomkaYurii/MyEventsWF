using Microsoft.EntityFrameworkCore;
using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;
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
                                    .ThenInclude(user => user.Role)
                                 .Include(ev => ev.Gallery)
                                 .Include(ev => ev.Country)
                                 .Include(ev => ev.City)
                                 .Include(ev => ev.CategoriesEvents)
                                    .ThenInclude(ce => ce.Category)
                                 .SingleOrDefaultAsync(ev => ev.Id == id);
        return my_event ?? throw new EntityNotFoundException("NOT FOUND");
    }

    public async Task<IEnumerable<Event>> GetTop10EventsAsync()
    {
        return await Task.Run(() => databaseContext.Events
            .OrderByDescending(X => X.DateOfEvent)
            .Take(10));
    }
}
