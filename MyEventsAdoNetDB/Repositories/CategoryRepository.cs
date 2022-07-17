using Dapper;
using Dapper_Example.DAL;
using MyEventsAdoNetDB.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MyEventsAdoNetDB.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Categories")
        {
        }

        public async Task<IEnumerable<Category>> TopFiveCategoryAsync()
        {
            string sql = @"SELECT TOP 5 * FROM Category";
            var results = await _sqlConnection.QueryAsync<Category>(sql,
                transaction: _dbTransaction);
            return results;
        }
    }
}
