using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_SmartShop.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? phoneNumber { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
