using Newtonsoft.Json;
using RestSharp;
using SmartShop_App.Models;
using SmartShop_App.Services;
using System.Collections.ObjectModel;
using Method = RestSharp.Method;

namespace SmartShop_App;

public partial class ProductPage : ContentPage
{

	public ProductPage()
	{
		InitializeComponent();
		LoadProducts();
		BindingContext = this;

	}


	public async void LoadProducts()
	{
		ProductService productService = new ProductService();
		//Products = await productService.Products();

		foreach (var r in await productService.Products())
		{
			Products.Add(r);
		}
    }


	public ObservableCollection<ProductInfo> Products { get; set; } = new();


    public void StartWith(object sender, TextChangedEventArgs e)
	{
		//myList.Where(s => s.Name.StartsWith());
	}

	public async void GoBackBtnAsync(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new LoginPage());
	}

	private async void ProfilePageBtn_ClickedAsync(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new ProfilePage());
    }

	private async void OrderPageBtn_ClickedAsync(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new MyOrdersPage());
    }

    private async void OnGeoLocation(object sender, EventArgs e)
    {
        try
        {
            var location = await GetLocationAsync();
            if (location != null)
            {
                // Use the location
                //LatitudeLabel.Text = $"Latitude: {location.Latitude}";
                //LongitudeLabel.Text = $"Longitude: {location.Longitude}";
                await DisplayAlert("Information", $" Your Location is: \n Latitude: {location.Latitude} \n Longitude: {location.Longitude}", "Ok");
            }
            else
            {
                // Location not available
                await DisplayAlert("Warning", "Location not found", "Ok");
            }
        }
        catch (Exception ex)
        {
            // Handle error
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
     


    private async Task<Location> GetLocationAsync()
    {
        try
        {
            // Obtain the public IP address of the device
            var client = new RestClient("https://api.ipgeolocation.io");
            var request = new RestRequest($"/ipgeo?apiKey=8c35598ef52b486d952b078598d3a6fa", Method.Get);
            var response = await client.ExecuteAsync(request);
            var content = response.Content;
            var ipInfo = JsonConvert.DeserializeObject<IPInformation>(content);

           
            // Convert the location data to a Location object
            var location = new Location(ipInfo.Latitude, ipInfo.Longitude);

            return location;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

}