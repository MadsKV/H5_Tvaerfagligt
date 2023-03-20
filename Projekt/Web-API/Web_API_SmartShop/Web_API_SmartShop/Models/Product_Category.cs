using System.ComponentModel.DataAnnotations;
namespace Web_API_SmartShop.Models
{
    public class Product_Category
    {
        [Key]
        public int PCId { get; set; }
        public int categoryId { get; set; }
        public int productId { get; set; }
    }
}
