using Newtonsoft.Json;
using ShoppingMall.MVC.Models;

namespace ShoppingMall.MVC.Services
{
    public interface IUserRegistrationService
    {
        Task<IEnumerable<UserRegistration>> GetAllUserRegistrations();
        Task<UserRegistration> GetUserRegistrationDetails(int id);
        Task<UserRegistration> Add(UserRegistration item);
        Task Update(int id, UserRegistration item);
        Task Delete(int id);
    }
    public class UserRegistrationService : IUserRegistrationService
    {
        string _remoteServiceBaseUrl;
        public UserRegistrationService(IConfiguration config)
        {
            _remoteServiceBaseUrl = config["ShoppingMallAPIUrl"];
        }

        public async Task<IEnumerable<UserRegistration>> GetAllUserRegistrations()
        {
            var client = new HttpClient();
            var result = await client.GetAsync(_remoteServiceBaseUrl + "/UserRegistrations/");
            result.EnsureSuccessStatusCode();
            var dataString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<UserRegistration>>(dataString);
        }

        public async Task<UserRegistration> GetUserRegistrationDetails(int id)
        {
            HttpClient client = new HttpClient();
            string strjson = await client.GetStringAsync(_remoteServiceBaseUrl + "/UserRegistrations/" + id);
            UserRegistration items = JsonConvert.DeserializeObject<UserRegistration>(strjson);
            return items;
        }
        public async Task<UserRegistration> Add(UserRegistration item)
        {
            HttpClient client = new HttpClient();
            var result = await client.PostAsJsonAsync(_remoteServiceBaseUrl + "/UserRegistrations/", item);
            result.EnsureSuccessStatusCode();
            return item;
        }

        public async Task Update(int id, UserRegistration item)
        {
            HttpClient client = new HttpClient();
            var result = await client.PutAsJsonAsync(_remoteServiceBaseUrl + "/UserRegistrations/" + id, item);
            result.EnsureSuccessStatusCode();
        }
        public async Task Delete(int id)
        {
            HttpClient client = new HttpClient();
            var result = await client.DeleteAsync(_remoteServiceBaseUrl + "/UserRegistrations/" + id);
            result.EnsureSuccessStatusCode();
        }
    }
}
