namespace MyEventsAdoNetDB.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository _eventRepository { get; }
        IUserProfileRepository _userProfileRepository { get; }
        ICategoryRepository _categoryRepository { get; }
        IGalleryRepository _galleryRepository { get; }
        IMessageRepository _messageRepository { get; }
        void Commit();
        void Dispose();
    }
}
