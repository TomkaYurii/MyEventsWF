namespace MyEventsEntityFrameworkDb.EFRepositories.Contracts;

public interface IEFUnitOfWork
{
    IEFCategoryRepository EFCategoryRepository { get; }
    IEFEventRepository EFEventRepository { get; }
    IEFGalleryRepository EFGalleryRepository { get; }
    IEFImageRepository EFImageRepository { get; }
    IEFMessageRepository EFMessageRepository { get; }
    IEFUserProfileRepository EFUserProfileRepository { get; }
    Task SaveChangesAsync();
}
