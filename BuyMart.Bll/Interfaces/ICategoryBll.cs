using BuyMart.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyMart.BLL.Interfaces
{
    public interface ICategoryBLL
    {
        IQueryable<Category> GetAllCategories();
        Category GetCategoryById(int id);
       
        
    }
}
