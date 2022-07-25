using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsAdoNetDB.Repositories.Interfaces
{
    public  interface IEventRepository : IGenericRepository<Event>
    {
    }
}
