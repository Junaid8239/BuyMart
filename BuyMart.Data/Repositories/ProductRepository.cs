using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyMart.Data;
using BuyMart.Data.Models;
using BuyMart.Data.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BuyMart.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }

        public IEnumerable<Product> SearchProducts(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return _db.Products.ToList();
            }

            return _db.Products
                .Where(p => p.Name.ToLower().Contains(query.ToLower()) || p.Description.ToLower().Contains(query.ToLower()))
                .ToList();
        }
    }
}
