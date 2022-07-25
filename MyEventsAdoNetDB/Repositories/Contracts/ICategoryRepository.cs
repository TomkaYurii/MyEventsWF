using Dapper_Example.DAL;

namespace MyEventsAdoNetDB.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> TopFiveCategoryAsync();
    }
}
