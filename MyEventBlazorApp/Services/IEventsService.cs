namespace MyEventBlazorApp.Services
{
    public interface IEventsService
    {
        Task<IEnumerable<string>> GetEvents();
    }
}
