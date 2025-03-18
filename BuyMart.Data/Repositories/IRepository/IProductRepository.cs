using System.Collections.Generic;
using System.Threading.Tasks;
using BuyMart.Data.Models;


namespace BuyMart.Data.Repositories.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        IEnumerable<Product> SearchProducts(string query);

    }
}

