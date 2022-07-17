using Dapper;
using Dapper_Example.DAL;
using MyEventsAdoNetDB.Entities;
using MyEventsAdoNetDB.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MyEventsAdoNetDB.Repositories
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Users")
        {
        }

    }
}
