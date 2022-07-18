using Dapper_Example.DAL;
using MyEventsAdoNetDB.Entities;

namespace MyEventsAdoNetDB.Repositories.Interfaces
{
    public interface IMessageRepository : IGenericRepository<ForumPost>
    {
        Task<IEnumerable<ForumPost>> MessageByEventAsync(int EventId);
    }
}
