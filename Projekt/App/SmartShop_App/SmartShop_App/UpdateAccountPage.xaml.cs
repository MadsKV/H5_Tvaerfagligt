using Microsoft.Maui.ApplicationModel.Communication;
using SmartShop_App.Services;

namespace SmartShop_App;

public partial class UpdateAccountPage : ContentPage
{
    readonly ILoginRepository _loginRepository = new LoginService();
    public UpdateAccountPage()
	{
		InitializeComponent();
	}

    public async void SubmitBtn_Clicked(object sender, EventArgs e)
    {
        string email = LoginService.Email;
        string password = changePassword.Text;
        string phoneNumber = ChangePhoneNumber.Text;

        await _loginRepository.UpdateUser(email, password, phoneNumber);

        if (email == null || email == "" || password == null || password == "" || phoneNumber == null || phoneNumber == "")
        {
            await DisplayAlert("Failed", "Update Failed", "Ok");
        }
        else
        {
            await DisplayAlert("Success!", "Your account has been updated and you will be redirected to the product page", "Ok");
            await Navigation.PushAsync(new ProductPage());
        }
    }
}