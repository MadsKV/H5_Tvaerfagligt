using Microsoft.Maui.ApplicationModel.Communication;
using SmartShop_App.Services;

namespace SmartShop_App;

public partial class ProfilePage : ContentPage
{
    readonly ILoginRepository _loginRepository = new LoginService();
    public ProfilePage()
	{
		InitializeComponent();
	}


    private async void deleteBtn_Clicked(object sender, EventArgs e)
    {
        string email = LoginService.Email;

        await _loginRepository.DeleteUser(email);

        if (email == null || email == "")
        {
            await DisplayAlert("Failed", "Failed to delete account", "Ok");
        }
        else
        {
            await DisplayAlert("Success!", "Your account has been deleted and you will be redirected to the login page", "Ok");
            await Navigation.PushAsync(new LoginPage());
        }
    }

    private async void updateBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UpdateAccountPage());
    }
}