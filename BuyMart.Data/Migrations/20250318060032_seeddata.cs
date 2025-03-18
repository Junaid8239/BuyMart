using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuyMart.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://th.bing.com/th/id/OIP.5k8xtdEpB82aUSNURMtVOAHaEK?rs=1&pid=ImgDetMain", "Electronics" },
                    { 2, "https://th.bing.com/th/id/OIP.Kc4LEsU19nGbEmxMFyG9fAHaFI?rs=1&pid=ImgDetMain", "Clothing" },
                    { 3, "https://th.bing.com/th/id/OIP.n3sAXxDyR0gM6xT1ZwmXdQHaE8?rs=1&pid=ImgDetMain", "Books" },
                    { 4, "https://www.news4user.com/wp-content/uploads/2023/08/90970312.webp", "Home Appliances" },
                    { 5, "https://static.vecteezy.com/system/resources/previews/028/535/140/large_2x/many-colorful-toys-collection-on-the-desk-generative-ai-photo.jpg", "Toys" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 2, 1, "A high-performance laptop with 16GB RAM and 512GB SSD.", "https://cdn.mos.cms.futurecdn.net/gnG2Z6pK7CTBJmw4pRUy8i.jpg", "Laptop", 999.99m },
                    { 3, 1, "Latest smartphone with 5G support and 128GB storage.", "https://www.worldshop.eu/medias/img/8941305692190_w1500_z_717540126/apple-iphone15promax-smartphone-256gb-natural-titanium.jpeg", "Smartphone", 699.99m },
                    { 4, 1, "Wireless noise-canceling headphones with deep bass.", "https://www.bhphotovideo.com/images/images2500x2500/beats_by_dr_dre_900_00183_01_studio_wireless_over_ear_headphone_1037578.jpg", "Headphones", 49.99m },
                    { 5, 2, "100% cotton comfortable t-shirt for everyday wear.", "https://th.bing.com/th/id/OIP.RHzRocDQ-VPOif5AmSbAeQHaKl?rs=1&pid=ImgDetMain", "T-Shirt", 19.99m },
                    { 6, 2, "Slim fit blue jeans made from high-quality denim.", "https://i5.walmartimages.com/asr/eb9aaf39-7462-44c9-bd86-274cfb1d38fb_1.1440eb2973046b94785da8e1d9c4108f.jpeg", "Jeans", 39.99m },
                    { 7, 3, "Learn C# with hands-on projects and real-world examples.", "https://i5.walmartimages.com/asr/6ce339ee-e613-4052-ada2-2154d56b4079_1.c800e07a14374d96506e741906f3a907.jpeg", "C# Programming Book", 29.99m },
                    { 8, 4, "Energy-efficient refrigerator with a capacity of 350L.", "https://th.bing.com/th/id/OIP.ItyEWfwgW8YqEEs8jkjWyQHaHa?rs=1&pid=ImgDetMain", "Refrigerator", 499.99m },
                    { 9, 4, "Compact microwave oven with multiple cooking modes.", "https://www.fisherpaykel.com/images/kitchen/cook/built-in-ovens/gallery/OB76DDEPX3-feature-365-gal.jpg", "Microwave Oven", 199.99m },
                    { 10, 5, "Battery-operated remote control toy car.", "https://i5.walmartimages.com/asr/f757fa39-c626-44cd-ab92-b46358749392_1.8edb8080c26be49e94dc284ed5ac7c06.jpeg?odnWidth=1000&odnHeight=1000&odnBg=ffffff", "Toy Car", 9.99m },
                    { 11, 5, "Soft and cuddly teddy bear for kids.", "https://microless.com/cdn/products/5d0502b2d06ccd9932ddb48a82ca40b3-hi.jpg", "Teddy Bear", 14.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
