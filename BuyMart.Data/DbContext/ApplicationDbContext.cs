using BuyMart.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuyMart.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }



        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", ImageUrl = "https://th.bing.com/th/id/OIP.5k8xtdEpB82aUSNURMtVOAHaEK?rs=1&pid=ImgDetMain" },
                new Category { Id = 2, Name = "Clothing", ImageUrl = "https://th.bing.com/th/id/OIP.Kc4LEsU19nGbEmxMFyG9fAHaFI?rs=1&pid=ImgDetMain" },
                new Category { Id = 3, Name = "Books", ImageUrl = "https://th.bing.com/th/id/OIP.n3sAXxDyR0gM6xT1ZwmXdQHaE8?rs=1&pid=ImgDetMain" },
                new Category { Id = 4, Name = "Home Appliances", ImageUrl = "https://www.news4user.com/wp-content/uploads/2023/08/90970312.webp" },
                new Category { Id = 5, Name = "Toys", ImageUrl = "https://static.vecteezy.com/system/resources/previews/028/535/140/large_2x/many-colorful-toys-collection-on-the-desk-generative-ai-photo.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 2, Name = "Laptop", Price = 999.99m, Description = "A high-performance laptop with 16GB RAM and 512GB SSD.", CategoryId = 1, ImageUrl = "https://cdn.mos.cms.futurecdn.net/gnG2Z6pK7CTBJmw4pRUy8i.jpg" },
                new Product { Id = 3, Name = "Smartphone", Price = 699.99m, Description = "Latest smartphone with 5G support and 128GB storage.", CategoryId = 1, ImageUrl = "https://www.worldshop.eu/medias/img/8941305692190_w1500_z_717540126/apple-iphone15promax-smartphone-256gb-natural-titanium.jpeg" },
                new Product { Id = 4, Name = "Headphones", Price = 49.99m, Description = "Wireless noise-canceling headphones with deep bass.", CategoryId = 1, ImageUrl = "https://www.bhphotovideo.com/images/images2500x2500/beats_by_dr_dre_900_00183_01_studio_wireless_over_ear_headphone_1037578.jpg" },
                new Product { Id = 5, Name = "T-Shirt", Price = 19.99m, Description = "100% cotton comfortable t-shirt for everyday wear.", CategoryId = 2, ImageUrl = "https://th.bing.com/th/id/OIP.RHzRocDQ-VPOif5AmSbAeQHaKl?rs=1&pid=ImgDetMain" },
                new Product { Id = 6, Name = "Jeans", Price = 39.99m, Description = "Slim fit blue jeans made from high-quality denim.", CategoryId = 2, ImageUrl = "https://i5.walmartimages.com/asr/eb9aaf39-7462-44c9-bd86-274cfb1d38fb_1.1440eb2973046b94785da8e1d9c4108f.jpeg" },
                new Product { Id = 7, Name = "C# Programming Book", Price = 29.99m, Description = "Learn C# with hands-on projects and real-world examples.", CategoryId = 3, ImageUrl = "https://i5.walmartimages.com/asr/6ce339ee-e613-4052-ada2-2154d56b4079_1.c800e07a14374d96506e741906f3a907.jpeg" },
                new Product { Id = 8, Name = "Refrigerator", Price = 499.99m, Description = "Energy-efficient refrigerator with a capacity of 350L.", CategoryId = 4, ImageUrl = "https://th.bing.com/th/id/OIP.ItyEWfwgW8YqEEs8jkjWyQHaHa?rs=1&pid=ImgDetMain" },
                new Product { Id = 9, Name = "Microwave Oven", Price = 199.99m, Description = "Compact microwave oven with multiple cooking modes.", CategoryId = 4, ImageUrl = "https://www.fisherpaykel.com/images/kitchen/cook/built-in-ovens/gallery/OB76DDEPX3-feature-365-gal.jpg" },
                new Product { Id = 10, Name = "Toy Car", Price = 9.99m, Description = "Battery-operated remote control toy car.", CategoryId = 5, ImageUrl = "https://i5.walmartimages.com/asr/f757fa39-c626-44cd-ab92-b46358749392_1.8edb8080c26be49e94dc284ed5ac7c06.jpeg?odnWidth=1000&odnHeight=1000&odnBg=ffffff" },
                new Product { Id = 11, Name = "Teddy Bear", Price = 14.99m, Description = "Soft and cuddly teddy bear for kids.", CategoryId = 5, ImageUrl = "https://microless.com/cdn/products/5d0502b2d06ccd9932ddb48a82ca40b3-hi.jpg" }
            );
        }





    }
}
