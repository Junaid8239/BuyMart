using BuyMart.BLL.Interfaces;
using BuyMart.Data.Models;
using BuyMart.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BuyMart.Presentation.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductBLL _productBLL;//no underscore
       

        public ProductController(IProductBLL productService)
        {
            _productBLL = productService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var products =  _productBLL.GetAllProducts();
            var viewModel = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
                ImageUrl = p.ImageUrl
            }).ToList();

            return View(viewModel);
        }

        
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product ID.");
            }

            var product =  _productBLL.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            // ✅ Convert Product to ProductViewModel
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category?.Name // Ensuring Category is not null
            };

            return View(productViewModel);
        }

        [HttpGet("Search")]
        public IActionResult Search(string query)
        {
            var matchingProducts = _productBLL.SearchProducts(query);

            var productViewModels = matchingProducts.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Description = p.Description,
                
            }).ToList();

            return View("Index", productViewModels);
        }



    }
}
