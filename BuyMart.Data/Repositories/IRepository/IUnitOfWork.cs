using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMart.Data.Repositories.IRepository
{
    public interface IUnitOfWork   
    {
        ICategoryRepository Category { get; }

        IProductRepository Product { get; }

        ICartRepository CartItem { get; }

        void Save();

    }
}
