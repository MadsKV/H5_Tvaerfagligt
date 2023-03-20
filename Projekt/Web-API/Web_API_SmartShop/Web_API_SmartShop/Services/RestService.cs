using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Text.Json;

namespace Web_API_SmartShop.Services
{
    //public class RestService : IRestService
    //{
    //    HttpClient _client;
    //    JsonSerializerOptions _serializerOptions;

    //    public List<TodoItem> Items { get; private set; }

    //    public RestService()
    //    {
    //        _client = new HttpClient();
    //        _serializerOptions = new JsonSerializerOptions
    //        {
    //            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    //            WriteIndented = true
    //        };
    //    }
    //}


    //public async Task<List<TodoItem>> RefreshDataAsync()
    //{
    //    Items = new List<TodoItem>();

    //    Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
    //    try
    //    {
    //        HttpResponseMessage response = await _client.GetAsync(uri);
    //        if (response.IsSuccessStatusCode)
    //        {
    //            string content = await response.Content.ReadAsStringAsync();
    //            Items = JsonSerializer.Deserialize<List<TodoItem>>(content, _serializerOptions);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(@"\tERROR {0}", ex.Message);
    //    }

    //    return Items;
    //}
}
