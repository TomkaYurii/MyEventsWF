using Dapper;
using MyEventsAdoNetDB.Entities;
using MyEventsAdoNetDB.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MyEventsAdoNetDB.Repositories
{
    public class MessageRepository : GenericRepository<ForumPost>, IMessageRepository
    {
        public MessageRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Messages")
        {
        }

        public async Task<IEnumerable<ForumPost>> AllMessagesByEventName(string name)
        {
            string sql = @"SELECT Messages.id, Events.user_id, event_id, message FROM Events INNER JOIN Messages ON Events.id = Messages.event_id WHERE Events.name = N'@EventName'";
            return await _sqlConnection.QueryAsync<ForumPost>(sql, param: new { EventName = name }, transaction: _dbTransaction);
        }

        public async Task<IEnumerable<ForumPost>> AllMessagesByEventId(int id)
        {
            string sql = @"SELECT * FROM Messages WHERE event_id = @EventId";
            return await _sqlConnection.QueryAsync<ForumPost>(sql, param: new { EventId = id }, transaction: _dbTransaction);
        }
        public async Task<IEnumerable<ForumPost>> AllMessagesByEventIdAndName(int id, string name)
        {
            string sql = @"SELECT Messages.id, Events.user_id, event_id, message FROM Events INNER JOIN Messages ON Events.id = Messages.event_id WHERE Events.name = N'@EventName' AND event_id = @EventId";
            return await _sqlConnection.QueryAsync<ForumPost>(sql, param: new { EventId = id, EventName = name }, transaction: _dbTransaction);
        }
    }
}
