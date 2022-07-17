using MyEventsAdoNetDB.Repositories.Interfaces;
using System.Data;

namespace MyEventsAdoNetDB.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IEventRepository _eventRepository { get; }
        public ICategoryRepository _categoryRepository { get; }
        public IUserProfileRepository _userProfileRepository { get; }
        public IGalleryRepository _galleryRepository { get; }
        public IMessageRepository _messageRepository { get; }

        readonly IDbTransaction _dbTransaction;

        public UnitOfWork(
            IUserProfileRepository userProfileRepository,
            IEventRepository eventRepository,
            ICategoryRepository categoryRepository, 
            IGalleryRepository galleryRepository,
            IMessageRepository messageRepository,
            IDbTransaction dbTransaction)
        {
            _userProfileRepository = userProfileRepository;
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _galleryRepository = galleryRepository;
            _messageRepository = messageRepository;
            _dbTransaction = dbTransaction;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
                // By adding this we can have muliple transactions as part of a single request
                //_dbTransaction.Connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                _dbTransaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {
            //Close the SQL Connection and dispose the objects
            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }
    }
}
