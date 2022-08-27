using Newtonsoft.Json;
using ShoppingMall.MVC.Models;

namespace ShoppingMall.MVC.Services
{
    public interface IMallService
    {
        Task<IEnumerable<Mall>> GetAllMalls();
        Task<Mall> GetMallDetails(int id);
        Task<Mall> Add(Mall item);
        Task Update(int id, Mall item);
        Task Delete(int id);
    }
    public class MallService : IMallService
    {
        string _remoteServiceBaseUrl;
        public MallService(IConfiguration config)
        {
            _remoteServiceBaseUrl = config["ShoppingMallAPIUrl"];
        }

        public async Task<IEnumerable<Mall>> GetAllMalls()
        {
            var client = new HttpClient();
            var result = await client.GetAsync(_remoteServiceBaseUrl + "/Malls/");
            result.EnsureSuccessStatusCode();
            var dataString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Mall>>(dataString);
        }

        public async Task<Mall> GetMallDetails(int id)
        {
            HttpClient client = new HttpClient();
            string strjson = await client.GetStringAsync(_remoteServiceBaseUrl + "/Malls/" + id);
            Mall items = JsonConvert.DeserializeObject<Mall>(strjson);
            return items;
        }
        public async Task<Mall> Add(Mall item)
        {
            HttpClient client = new HttpClient();
            var result = await client.PostAsJsonAsync(_remoteServiceBaseUrl + "/Malls/", item);
            result.EnsureSuccessStatusCode();
            return item;
        }

        public async Task Update(int id, Mall item)
        {
            HttpClient client = new HttpClient();
            var result = await client.PutAsJsonAsync(_remoteServiceBaseUrl + "/Malls/" + id, item);
            result.EnsureSuccessStatusCode();
        }
        public async Task Delete(int id)
        {
            HttpClient client = new HttpClient();
            var result = await client.DeleteAsync(_remoteServiceBaseUrl + "/Malls/" + id);
            result.EnsureSuccessStatusCode();
        }
    }
}
