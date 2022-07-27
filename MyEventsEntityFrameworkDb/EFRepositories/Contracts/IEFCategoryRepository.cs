using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories.Contracts;

public interface IEFCategoryRepository : IEFGenericRepository<Category>
{
    Task<IEnumerable<Category>> TopFiveCategoryAsync();
}
