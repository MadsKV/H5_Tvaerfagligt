namespace SmartShop_App.Controls;

public partial class OrderView : ContentView
{
    public static readonly BindableProperty OrderInfoProperty = BindableProperty.Create(nameof(OrderId), typeof(string), typeof(OrderView), string.Empty);
    public static readonly BindableProperty ProductIdProperty = BindableProperty.Create(nameof(ProductId), typeof(string), typeof(OrderView), string.Empty);
    public static readonly BindableProperty AmountInfoProperty = BindableProperty.Create(nameof(OrderAmount), typeof(string), typeof(OrderView), string.Empty);
    public static readonly BindableProperty OrderDateProperty = BindableProperty.Create(nameof(OrderDate), typeof(string), typeof(OrderView), string.Empty);
    public static readonly BindableProperty OrderStatus = BindableProperty.Create(nameof(OrderStatusInfo), typeof(string), typeof(OrderView), string.Empty);
    public static readonly BindableProperty ShippingAddressProperty = BindableProperty.Create(nameof(ShippingAddress), typeof(string), typeof(OrderView), string.Empty);
    public static readonly BindableProperty BillingAddressProperty = BindableProperty.Create(nameof(BillingAddress), typeof(string), typeof(OrderView), string.Empty);
    public static readonly BindableProperty ShippingCostProperty = BindableProperty.Create(nameof(ShippingCost), typeof(string), typeof(OrderView), string.Empty);
    public static readonly BindableProperty ShippingTypeProperty = BindableProperty.Create(nameof(ShippingType), typeof(string), typeof(OrderView), string.Empty);

    public string OrderId
    {
        get => (string)GetValue(OrderView.OrderInfoProperty);
        set => SetValue(OrderView.OrderInfoProperty, value);
    }
    public string OrderAmount
    {
        get => (string)GetValue(OrderView.AmountInfoProperty);
        set => SetValue(OrderView.AmountInfoProperty, value);
    }
    public string ProductId
    {
        get => (string)GetValue(OrderView.AmountInfoProperty);
        set => SetValue(OrderView.AmountInfoProperty, value);
    }
    public DateTime OrderDate
    {
        get => (DateTime)GetValue(OrderView.AmountInfoProperty);
        set => SetValue(OrderView.AmountInfoProperty, value);
    }
    public string OrderStatusInfo
    {
        get => (string)GetValue(OrderView.AmountInfoProperty);
        set => SetValue(OrderView.AmountInfoProperty, value);
    }
    public int ShippingAddress
    {
        get => (int)GetValue(OrderView.AmountInfoProperty);
        set => SetValue(OrderView.AmountInfoProperty, value);
    }
    public int BillingAddress
    {
        get => (int)GetValue(OrderView.AmountInfoProperty);
        set => SetValue(OrderView.AmountInfoProperty, value);
    }
    public float ShippingCost
    {
        get => (float)GetValue(OrderView.AmountInfoProperty);
        set => SetValue(OrderView.AmountInfoProperty, value);
    }
    public int ShippingType
    {
        get => (int)GetValue(OrderView.AmountInfoProperty);
        set => SetValue(OrderView.AmountInfoProperty, value);
    }

    public OrderView()
    {
        InitializeComponent();
        BindingContext = this;
    }
}