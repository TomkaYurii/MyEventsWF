using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;
using System.Data;

namespace MyEventsEntityFrameworkDb.EFRepositories;

public class EFCategoryRepository : EFGenericRepository<Category>, IEFCategoryRepository
{
    public EFCategoryRepository(MyEventsDbContext databaseContext)
        : base(databaseContext)
    {
    }

    public override Task<Category> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> TopFiveCategoryAsync()
    {
        return databaseContext.Categories.Take(5);
    }
}
