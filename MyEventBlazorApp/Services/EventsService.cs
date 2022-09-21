using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using MyEventsEntityFrameworkDb.Entities;
using System.Net.Http;
using System.Text.Json;

namespace MyEventBlazorApp.Services
{
    public class EventsService
    {
        private readonly HttpClient _httpClient;

        public EventsService(HttpClient httpClient) =>
                _httpClient = httpClient;

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var response = await _httpClient.GetAsync("api/events");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <IEnumerable<Event>>(responseStream);
        }
    }
}
