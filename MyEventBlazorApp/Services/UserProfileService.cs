using MyEventsAdoNetDB.Entities;

namespace MyEventBlazorApp.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly HttpClient _httpClient;

        public UserProfileService(HttpClient httpClient) =>
                _httpClient = httpClient;

        public async Task<UserProfile> GetUserProfileById()
        {
            return await _httpClient.GetFromJsonAsync<UserProfile>("api/User/3");
        }
    }
}
