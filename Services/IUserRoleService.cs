using Newtonsoft.Json;
using ShoppingMall.MVC.Models;

namespace ShoppingMall.MVC.Services
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRole>> GetAllUserRoles();
        Task<UserRole> GetUserRoleDetails(int id);
    }
    public class UserRoleService : IUserRoleService
    {
        string _remoteServiceBaseUrl;
        public UserRoleService(IConfiguration config)
        {
            _remoteServiceBaseUrl = config["ShoppingMallAPIUrl"];
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRoles()
        {
            var client = new HttpClient();
            var result = await client.GetAsync(_remoteServiceBaseUrl + "/UserRoles/");
            result.EnsureSuccessStatusCode();
            var dataString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<UserRole>>(dataString);
        }

        public async Task<UserRole> GetUserRoleDetails(int id)
        {
            HttpClient client = new HttpClient();
            string strjson = await client.GetStringAsync(_remoteServiceBaseUrl + "/UserRoles/" + id);
            UserRole items = JsonConvert.DeserializeObject<UserRole>(strjson);
            return items;
        }
    }
}
