namespace MyEventsAdoNetDB.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository _productRepository { get; }

        ICategoryRepository _categoryRepository { get; }
        void Commit();
        void Dispose();
    }
}
