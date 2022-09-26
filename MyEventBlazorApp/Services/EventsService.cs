using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using MyEventsAdoNetDB.Entities;
using System.Net.Http;
using System.Text.Json;

namespace MyEventBlazorApp.Services
{
    public class EventsService : IEventsService
    {
        private readonly HttpClient _httpClient;

        public EventsService(HttpClient httpClient) =>
                _httpClient = httpClient;

        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Event>>("api/events");
        }
    }
}
