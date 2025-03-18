using System.Collections.Generic;
using System.Threading.Tasks;
using BuyMart.BLL.Interfaces;
using BuyMart.Data.Models;
using BuyMart.Data.Repositories.IRepository;

public class CategoryBLL : ICategoryBLL
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryBLL(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IQueryable<Category> GetAllCategories()
    {
        return _unitOfWork.Category.GetAll(null);
    }

    public Category GetCategoryById(int id)
    {
        return _unitOfWork.Category.Get(c => c.Id == id);
    }
}
