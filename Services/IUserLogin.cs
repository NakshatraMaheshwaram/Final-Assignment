using Newtonsoft.Json;
using ShoppingMall.MVC.Models;

namespace ShoppingMall.MVC.Services
{
    public interface IUserLoginService
    {
        Task<UserRegistration> UserLogin(UserLoginViewModel userLoginViewModel);
    }
    public class UserLoginService : IUserLoginService
    {
        string _remoteServiceBaseUrl;
        public UserLoginService(IConfiguration config)
        {
            _remoteServiceBaseUrl = config["ShoppingMallAPIUrl"];
        }
        public async Task<UserRegistration> UserLogin(UserLoginViewModel userLoginViewModel)
        {
            HttpClient client = new HttpClient();
            string strjson = await client.GetStringAsync(new Uri(_remoteServiceBaseUrl + "/UserLogins?" + userLoginViewModel.EmailId + "&" + userLoginViewModel.Password));
            UserRegistration items = JsonConvert.DeserializeObject<UserRegistration>(strjson);
            return items;
        }
    }
}
