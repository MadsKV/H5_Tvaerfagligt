﻿using System.ComponentModel.DataAnnotations;
namespace Web_API_SmartShop.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public virtual ICollection<Product>? Products { get; set; }

    }
}
