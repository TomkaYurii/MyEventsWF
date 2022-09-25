using Microsoft.EntityFrameworkCore;
using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;
using MyEventsEntityFrameworkDb.Entities.Pagination;
using MyEventsEntityFrameworkDb.Exceptions;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

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
        // коли просто забираємо одну таблицю івентів не підтягуючи звязані дані для цієї таблиці
        //var source = table.Include(e=>e.User);

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

        // фільтруємо дані
        source = source.Where(ev => ev.DateOfEvent.Value.Year >= showEventParameters.MinYearOfEvent &&
            ev.DateOfEvent.Value.Year <= showEventParameters.MaxYearOfEvent);

        // шукаємо по сабстрінгам в імені
        source = source.Where(ev => ev.Name.Contains(showEventParameters.Name));

        // сортуємо попередньо вибрані дані по якомусь критерію
        ApplySort(ref source, showEventParameters.OrderBy);

        // прокидуємо отримані результати на пагінування
        var paginated_event_data = await PagedList<Event>.ToPagedListAsync(
                source,
                showEventParameters.PageNumber,
                showEventParameters.PageSize);

        // повертаємо пропагіновані дані
        return paginated_event_data;
    }

    public async Task<IEnumerable<Event>> GetEventsByName(string name)
    {
        var result = await this.databaseContext.Events.Where(e => e.Name == name).ToListAsync();
        return result;
    }

    //HELPER
    private void ApplySort(ref IQueryable<Event> events, string orderByQueryString)
    {
        if (!events.Any())
            return;
        if (string.IsNullOrWhiteSpace(orderByQueryString))
        {
            events = events.OrderBy(x => x.Name);
            return;
        }
        var eventParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(Event).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach (var param in eventParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;
            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
            if (objectProperty == null)
                continue;
            var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
            orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
        
        if (string.IsNullOrWhiteSpace(orderQuery))
        {
            events = events.OrderBy(x => x.DateOfEvent);
            return;
        }
         events = events.OrderBy(x => orderQuery);
    }

}
