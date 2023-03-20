using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop_App.Models
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public string? shippingAddress { get; set; }
        public string? shippingType { get; set; }
        public string? billingAddress { get; set; }
        public int orderAmount { get; set; }
        public DateTime createdDate { get; set; }
    }
}
