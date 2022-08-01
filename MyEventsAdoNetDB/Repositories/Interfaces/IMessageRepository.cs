using Dapper_Example.DAL;
using MyEventsAdoNetDB.Entities;

namespace MyEventsAdoNetDB.Repositories.Interfaces
{
    public interface IMessageRepository : IGenericRepository<ForumPost>
    {
        Task<IEnumerable<ForumPost>> AllMessagesByEventName(string name);
        Task<IEnumerable<ForumPost>> AllMessagesByEventId(int id);
        Task<IEnumerable<ForumPost>> AllMessagesByEventIdAndName(int id, string name);
        Task CreateMessage(int UserId, int EventId, string Message);
    }
}
