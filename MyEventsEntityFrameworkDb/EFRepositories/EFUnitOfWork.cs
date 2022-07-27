using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;

namespace MyEventsEntityFrameworkDb.EFRepositories;

public class EFUnitOfWork : IEFUnitOfWork
{
    protected readonly MyEventsDbContext databaseContext;

    public IEFCategoryRepository EFCategoryRepository { get; }
    public IEFEventRepository EFEventRepository { get; }
    public IEFGalleryRepository EFGalleryRepository { get; }
    public IEFImageRepository EFImageRepository { get; }
    public IEFMessageRepository EFMessageRepository { get; }
    public IEFUserProfileRepository EFUserProfileRepository { get; }

    public EFUnitOfWork(
        MyEventsDbContext databaseContext,
        IEFCategoryRepository EFCategoryRepository,
        IEFEventRepository EFEventRepository,
        IEFGalleryRepository EFGalleryRepository,
        IEFImageRepository EFImageRepository,
        IEFMessageRepository EFMessageRepository,
        IEFUserProfileRepository EFUserProfileRepository)
    {
        this.databaseContext = databaseContext;
        this.EFCategoryRepository = EFCategoryRepository;
        this.EFEventRepository = EFEventRepository;
        this.EFGalleryRepository = EFGalleryRepository;
        this.EFMessageRepository = EFMessageRepository;
        this.EFUserProfileRepository = EFUserProfileRepository;
        this.EFImageRepository = EFImageRepository;
    }

    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}