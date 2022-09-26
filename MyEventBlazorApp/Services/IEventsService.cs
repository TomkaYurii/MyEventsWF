

using MyEventsAdoNetDB.Entities;

namespace MyEventBlazorApp.Services
{
    public interface IEventsService
    {
        Task<IEnumerable<Event>> GetEvents();
    }
}
