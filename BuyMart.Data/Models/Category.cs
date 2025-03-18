using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyMart.Data.Models
{
    public class Category
    {
        [Key] // Primary Key
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Category Name should be between 2 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        [Url(ErrorMessage = "Invalid URL format")]
        public string ImageUrl { get; set; }

        // Navigation Property
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
