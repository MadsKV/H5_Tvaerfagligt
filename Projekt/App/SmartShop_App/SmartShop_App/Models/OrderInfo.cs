using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop_App.Models
{
    public class OrderInfo
    {
        public int OrderId { get; set; }
        public DateTime? orderDate { get; set; }
        public string? orderStatus { get; set; }

        public List<OrderDetails>? Details { get; set; } = new();
    }
}
