using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(MyEventsDbContext databaseContext)
            : base(databaseContext)
        {
        }

        public override Task<Event> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
