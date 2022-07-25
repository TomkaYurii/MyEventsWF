using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(MyEventsDbContext databaseContext)
            : base(databaseContext)
        {
        }

        public override Task<Message> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
