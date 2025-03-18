using BuyMart.Data.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuyMart.Data.Repositories
{
    public class UnitOfwork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        public ICartRepository CartItem { get; private set; }

        

        public UnitOfwork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            CartItem = new CartRepository(_db);

        }



        public void Save()
        {
            _db.SaveChanges();
        }

       
    }
}
