namespace SmartShop_App;
using Microsoft.Data.SqlClient;
using Microsoft.Maui.Devices.Sensors;
using SmartShop_App.Models;
using SmartShop_App.Services;
using System.Net;

public partial class LoginPage : ContentPage
{
    readonly ILoginRepository _loginRepository = new LoginService();
	public LoginPage()
	{
		InitializeComponent();
	}

	public async void LoginClicked(object sender, EventArgs e)
	{
        string userEmail = txtEmail.Text;
        string password = txtPassword.Text;
        if (userEmail == null || password == null)
        {
            await DisplayAlert("Warning", "Please Input Username & Password", "OK");
            return;
        }
        bool loggedIn = await _loginRepository.Login(userEmail, password);
        if(loggedIn)
        {
            //await Navigation.PushAsync(Application.Current.MainPage = new AppShell());
            //await Navigation.PushAsync(new TabbedPages());
            await Navigation.PushAsync(new ProductPage());
        }
        else
        {
            await DisplayAlert("Warning", "Username Or Password is Incorrect", "OK");
        }
    }

    public async void RegisterBtn(object sender, EventArgs e)
    {
        string email = await DisplayPromptAsync("Email", "What is your Email?");
        string password = await DisplayPromptAsync("Password", "What is your Password?");
        string phoneNumber = await DisplayPromptAsync("Phone Number", "What is your Phone Number??");

        await _loginRepository.NewUser(email, password, phoneNumber);


        if (email == null || email == "" || password == null || password == "" || phoneNumber == null || phoneNumber == "" )
        {
            await DisplayAlert("Failed", "Registration Failed", "Ok");
        }
        else
        {
            await DisplayAlert("Success!", "You are now successfully registered \nFeel free to login! :)", "Ok");
        }

    }

    
}