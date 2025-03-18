using BuyMart.Core.DTOs;
using BuyMart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMart.Data.Repositories.IRepository
{
    public interface ICartRepository : IRepository<CartItem>
    {
         void UpdateCartItem(CartItem item);

        public List<CartItemDto> GetCartItems(string userId);



    }

}
