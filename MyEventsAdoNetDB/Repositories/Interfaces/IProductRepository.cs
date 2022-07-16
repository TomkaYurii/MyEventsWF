using Dapper_Example.DAL;

namespace MyEventsAdoNetDB.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> ProductByCategoryAsync(int CategoryId);
    }
}
