using Dapper;
using Dapper_Example.DAL;
using MyEventsAdoNetDB.Entities;
using MyEventsAdoNetDB.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MyEventsAdoNetDB.Repositories
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Images")
        {

        }

        public async Task<IEnumerable<Image>> GetAllImagesByGalleryIdAsync(int id)
        {
            string sql = @"SELECT TOP 3 * FROM Images WHERE gallery_id = @gallery_id";
            IEnumerable<Image> results = await _sqlConnection.QueryAsync<Image>(sql,
                param: new { gallery_id = id },
                transaction: _dbTransaction);
            if (results == null)
                throw new KeyNotFoundException($"Images with this id of Gallery [{id}] could not be found.");
            return results;
        }
    }
}
