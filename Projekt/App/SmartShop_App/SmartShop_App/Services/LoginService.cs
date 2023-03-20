using Newtonsoft.Json;
using SmartShop_App.Services;
using SmartShop_App;
using System.Net;
using SmartShop_App.Models;
using System.Net.Http.Json;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;

public class LoginService : ILoginRepository
{
    public static string Email;
    public class LoginDTO
    {
        public string? email { get; set; }
        public string? password { get; set; }
    }
   
    public async Task<bool> Login(string email, string password)
    {
        var devSslHelper = new DevHttpsConnectionHelper(7004);
        var http = devSslHelper.HttpClient;

        string url = "https://10.0.2.2:7004/api/Login/";
        //client.BaseAddress = new Uri(url);
        LoginDTO login = new LoginDTO();
        login.email = email;
        login.password = password;
        var response = await http.PostAsJsonAsync(url, login);
        //HttpResponseMessage response = await client.GetAsync(url);
        //var response = await http.GetStringAsync(devSslHelper.DevServerRootUrl + $"/api/Customer?username={UserName}&password={Password}");
        string content = await response.Content.ReadAsStringAsync();

        if(content == "true")
        {
            Email = email;
            return await Task.FromResult(true);
        }
        else
        {
            return await Task.FromResult(false);
        }
    }

    public class newUserDTO
    {
        public string? email { get; set; }
        public string? password { get; set; }
        public string phoneNumber { get; set; }
    }

    public async Task<bool> NewUser(string email, string password, string phoneNumber)
    {

        var devSslHelper = new DevHttpsConnectionHelper(7004);
        var http = devSslHelper.HttpClient;

        string url = "https://10.0.2.2:7004/api/NewUser/";
        //client.BaseAddress = new Uri(url);
        newUserDTO newUser = new newUserDTO();
        newUser.email = email;
        newUser.password = password;
        newUser.phoneNumber = phoneNumber;
        var response = await http.PostAsJsonAsync(url, newUser);
        //HttpResponseMessage response = await client.GetAsync(url);
        //var response = await http.GetStringAsync(devSslHelper.DevServerRootUrl + $"/api/Customer?username={UserName}&password={Password}");
        string content = await response.Content.ReadAsStringAsync();
        if (content == "true")

        {
            return await Task.FromResult(true);
        }
        else
        {
            return await Task.FromResult(false);
        }
    }

    public async Task<bool> DeleteUser(string email)
    {

        var devSslHelper = new DevHttpsConnectionHelper(7004);
        var http = devSslHelper.HttpClient;

        string url = $"https://10.0.2.2:7004/api/DeleteCurrentUser/{email}";
        //client.BaseAddress = new Uri(url);
        newUserDTO newUser = new newUserDTO();
        newUser.email = email;
        var response =  await http.DeleteAsync(url);
        //HttpResponseMessage response = await client.GetAsync(url);
        //var response = await http.GetStringAsync(devSslHelper.DevServerRootUrl + $"/api/Customer?username={UserName}&password={Password}");
        string content = await response.Content.ReadAsStringAsync();
        if (content == "true")

        {
            return await Task.FromResult(true);
        }
        else
        {
            return await Task.FromResult(false);
        }
    }

    public async Task<bool> UpdateUser(string email, string password, string phoneNumber)
    {
        var devSslHelper = new DevHttpsConnectionHelper(7004);
        var http = devSslHelper.HttpClient;

        string url = $"https://10.0.2.2:7004/api/UpdateCurrentUser/{email}";
        //client.BaseAddress = new Uri(url);
        newUserDTO newUser = new newUserDTO();
        newUser.email = email;
        newUser.password = password;
        newUser.phoneNumber = phoneNumber;
        var response = await http.PutAsJsonAsync(url, newUser);
        //HttpResponseMessage response = await client.GetAsync(url);
        //var response = await http.GetStringAsync(devSslHelper.DevServerRootUrl + $"/api/Customer?username={UserName}&password={Password}");
        string content = await response.Content.ReadAsStringAsync();
        if (content == "true")

        {
            return await Task.FromResult(true);
        }
        else
        {
            return await Task.FromResult(false);
        }
    }
}
