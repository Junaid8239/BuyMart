using System.Collections.Generic;
using System.Threading.Tasks;
using BuyMart.Data.Models;



namespace BuyMart.Data.Repositories.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {

        void Update(Category obj);
   

    }
}
