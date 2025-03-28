﻿using System.ComponentModel.DataAnnotations;

namespace BuyMart.Presentation.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public string? Description { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
