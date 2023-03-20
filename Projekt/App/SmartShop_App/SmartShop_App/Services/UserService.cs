using Newtonsoft.Json;
using SmartShop_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop_App.Services
{
    public class UserService
    {
        public class UserDTO
        {

        }
        public async Task<ObservableCollection<UserInfo>> User()
        {

            ObservableCollection<UserInfo> results;
            var devSslHelper = new DevHttpsConnectionHelper(7004);
            var http = devSslHelper.HttpClient;



            string url = "https://10.0.2.2:7004/api/Products/";
            //client.BaseAddress = new Uri(url);
            var response = await http.GetAsync(url);
            //HttpResponseMessage response = await client.GetAsync(url);
            //var response = await http.GetStringAsync(devSslHelper.DevServerRootUrl + $"/api/Customer?username={UserName}&password={Password}");
            string content = await response.Content.ReadAsStringAsync();
            results = JsonConvert.DeserializeObject<ObservableCollection<UserInfo>>(content);


            return await Task.FromResult(results);

        }
    }
}
