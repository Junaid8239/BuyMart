using BuyMart.BLL.Interfaces;
using BuyMart.Data.Models;
using BuyMart.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BuyMart.Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryBLL categoryBLL;
        private readonly IProductBLL productBLL;


        public CategoryController(ICategoryBLL categoryBLL,IProductBLL productBLL)
        {
            this.categoryBLL = categoryBLL;
            this.productBLL = productBLL;
        }
        

        // GET: Category
        public async Task<IActionResult> Index()
        {
            var categories = categoryBLL.GetAllCategories();

            // Convert Entity to ViewModel
            var categoryViewModels = categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                ImageUrl = c.ImageUrl 
            }).ToList();

            return View(categoryViewModels);
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category =  categoryBLL.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            
            var products =  productBLL.GetProductsByCategoryId(id);

            // Convert Category Entity to ViewModel
            var categoryViewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl,
                Products = products.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                }).ToList()
            };

            return View(categoryViewModel);
        }

       
    }
}
