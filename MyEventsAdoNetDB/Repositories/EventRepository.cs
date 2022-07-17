using Dapper;
using Dapper_Example.DAL;
using MyEventsAdoNetDB.Entities;
using MyEventsAdoNetDB.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MyEventsAdoNetDB.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Events")
        {
        }

    }
}
