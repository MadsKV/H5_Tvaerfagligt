using SmartShop_App.Models;
using System;

namespace SmartShop_App;

public partial class MyOrdersPage : ContentPage
{
    public List<Orders> orders { get; set; }

    public MyOrdersPage()
	{
		InitializeComponent();
        BindingContext = this;



		orders = new List<Orders>()
		{
            new Orders{ OrderId= 1, orderStatus="Waiting", Details=new List<OrderDetails> ()
            { 
            new OrderDetails { orderAmount= 4, billingAddress = "Ditlev Bergs Vej 71, 3, 9", shippingAddress = "Ditlev Bergs Vej 71, 3, 9", OrderDetailId=2, shippingType="DBO" /*DateTime.Now(orde)*/ } 
            } 
            },

            new Orders{ OrderId= 2, orderStatus="Waiting",  }
        };

		ListOrders.ItemsSource= orders;
    }

	public class Orders
	{
        public int OrderId { get; set; }
        public DateTime? orderDate { get; set; }
        public string? orderStatus { get; set; }

        public List<OrderDetails>? Details { get; set; } = new();
        public List<ProductInfo>? Products { get; set; } = new();
    }

	public async void ProductBtn_ClickedAsync(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new ProductPage());
    }

    private void OrderSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }
}