using MyEventsAdoNetDB.Entities;

namespace MyEventBlazorApp.Services
{
    public interface IUserProfileService
    {
        Task<UserProfile> GetUserProfileById();
    }
}
