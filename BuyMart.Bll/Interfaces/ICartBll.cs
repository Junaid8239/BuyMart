using BuyMart.Core.DTOs;
using BuyMart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMart.Bll.Interfaces
{
    
        public interface ICartBll
        {
            bool AddToCart(string userId, int productId, int quantity);
            bool RemoveFromCart(string userId, int productId);
            bool ClearCart(string userId);
            List<CartItemDto> GetCartItems(string userId);
            bool MergeCart(string guestCartId, string userId);
            bool Checkout(string userId);
        }
    

}
