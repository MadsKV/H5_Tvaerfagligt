using Newtonsoft.Json;
using SmartShop_App.Services;
using SmartShop_App;
using System.Net;
using SmartShop_App.Models;
using System.Net.Http.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SmartShop_App.Services
{
    public class ProductService
    {

        public class ProductDTO
        {
            public int ProductId { get; set; }
            public string productName { get; set; }
            public float productPrice { get; set; }
        }
        public async Task<ObservableCollection<ProductInfo>> Products()
        {

            ObservableCollection<ProductInfo> results; 
            var devSslHelper = new DevHttpsConnectionHelper(7004);
            var http = devSslHelper.HttpClient;



            string url = "https://10.0.2.2:7004/api/Products/";
            //client.BaseAddress = new Uri(url);
            var response = await http.GetAsync(url);
            //HttpResponseMessage response = await client.GetAsync(url);
            //var response = await http.GetStringAsync(devSslHelper.DevServerRootUrl + $"/api/Customer?username={UserName}&password={Password}");
            string content = await response.Content.ReadAsStringAsync();
            results = JsonConvert.DeserializeObject<ObservableCollection<ProductInfo>>(content);


            return await Task.FromResult(results);
            
        }
    }
}
