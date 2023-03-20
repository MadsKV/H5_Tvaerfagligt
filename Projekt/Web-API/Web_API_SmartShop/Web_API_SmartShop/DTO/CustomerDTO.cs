using Web_API_SmartShop.Models;

namespace Web_API_SmartShop.DTO
{
        public class CustomerDTO
        {
            public int? CustomerId { get; set; }
            public string? Name { get; set; }
            public string? billingAddress { get; set; }
            public string? shippingAddress { get; set; }
        }

        
}
