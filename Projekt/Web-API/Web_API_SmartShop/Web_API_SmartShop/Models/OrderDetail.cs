using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_SmartShop.Models
{
    public class OrderDetail
    {
        [Key]
        public int orderDetailId { get; set; }
        public string? shippingAddress { get; set; }
        public string? shippingType { get; set; }
        public string? billingAddress { get; set; }
        public int orderAmount { get; set; }
        public DateTime createdDate { get; set; }



        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product? Products { get; set; }
    }
}
