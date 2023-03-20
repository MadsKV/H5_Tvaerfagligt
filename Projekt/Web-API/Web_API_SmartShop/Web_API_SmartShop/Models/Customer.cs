using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_SmartShop.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string ?Name { get; set; }
        public string ?billingAddress { get; set; }
        public string ?shippingAddress { get; set; }

        public virtual ICollection<User>? Users { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
            = new List<Order>();

        //[ForeignKey("OrderId")]
        //public int OrderId { get; set; }
        //public virtual Order? Orders { get; set; }
    }
}
