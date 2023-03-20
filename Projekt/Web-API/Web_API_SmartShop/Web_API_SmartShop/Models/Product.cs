using System.ComponentModel.DataAnnotations;
namespace Web_API_SmartShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ?productName { get; set; }
        public float productPrice { get; set; }
        public virtual ICollection<Category>? categories { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();
    }
}
