using BuyMart.BLL.Interfaces;
using BuyMart.Data;
using BuyMart.Data.Models;
using BuyMart.Data.Repositories;
using BuyMart.Data.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyMart.BLL
{
    public class ProductBLL : IProductBLL
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _unitOfWork.Product.GetAll(null);
        }

        public Product GetProductById(int id)
        {
            return _unitOfWork.Product.Get(p => p.Id == id);
        }

        public IQueryable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _unitOfWork.Product.GetAll(p => p.CategoryId == categoryId);
        }

        public IEnumerable<Product> SearchProducts(string query)
        {
            return _unitOfWork.Product.SearchProducts(query);
        }


    }
}
