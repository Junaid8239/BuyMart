using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyMart.Data.Models;
using BuyMart.Data;
using BuyMart.Data.Repositories.IRepository;
using System.Linq.Expressions;

namespace BuyMart.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }

}

