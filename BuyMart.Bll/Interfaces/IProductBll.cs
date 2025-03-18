using BuyMart.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyMart.BLL.Interfaces
{
    public interface IProductBLL
    {
        IQueryable<Product> GetAllProducts();
        Product GetProductById(int id);
        
        IQueryable<Product> GetProductsByCategoryId(int categoryId);
        IEnumerable<Product> SearchProducts(string query);
    }
}
