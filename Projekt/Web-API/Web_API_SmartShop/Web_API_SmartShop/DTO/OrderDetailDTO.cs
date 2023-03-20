namespace Web_API_SmartShop.DTO
{
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; set; }
        public string? shippingAddress { get; set; }
        public string? shippingType { get; set; }
        public string? billingAddress { get; set; }
        public int orderAmount { get; set; }
        public DateTime createdDate { get; set; }
    }
}
