using System.ComponentModel.DataAnnotations;

namespace BuyMart.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string HashPassword { get; set; }  // Hashed password

        [Required]
        public string Salt { get; set; }   // Store salt for password hashing
    }
}
