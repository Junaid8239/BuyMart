using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyMart.Data.Models
{
    public class CartItem
    {
        [Key] // Primary Key
        public int Id { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; } // Associate cart with logged-in user

        [Required(ErrorMessage = "ProductId is required")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        // Navigation Property
        public Product Product { get; set; }
    }
}
