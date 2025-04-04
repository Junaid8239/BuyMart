﻿namespace BuyMart.Presentation.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }  // Needed for edit/update
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }  // Foreign Key
        
        public string CategoryName { get; set; }
    }
}
