using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_SmartShop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        //public int customerId { get; set; }
        public DateTime ?orderDate { get; set; }
        public string ?orderStatus { get; set; }
        public string? shippingAddress { get; set; }
        public string? shippingType { get; set; }
        public float shippingCost { get; set; }
        public string? billingAddress { get; set; }
        public virtual List <OrderDetail> orderdetails { get; set; } = new();
        //public virtual ICollection<Customer> Customers { get; set; }
        //    = new List<Customer>();



        //[ForeignKey("orderDetailId")]
        //public int orderDetailId { get; set; }
        //public virtual OrderDetail? OrderDetail { get; set; }


        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
