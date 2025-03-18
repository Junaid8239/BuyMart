using BuyMart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyMart.Data.Repositories.IRepository;
using System.Linq.Expressions;
using BuyMart.Core.DTOs;

namespace BuyMart.Data.Repositories
{
    public class CartRepository : Repository<CartItem> , ICartRepository
    {
        private readonly ApplicationDbContext _db;

        public CartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void UpdateCartItem(CartItem item)
        {
            _db.CartItems.Update(item);
        }

        public List<CartItemDto> GetCartItems(string userId)
        {
            return (from cart in _db.CartItems
                    join product in _db.Products on cart.ProductId equals product.Id
                    where cart.UserId == userId
                    select new CartItemDto
                    {
                        CartItemId = cart.Id,
                        ProductId = product.Id,
                        ProductName = product.Name,
                        ImageUrl = product.ImageUrl,
                        Price = product.Price,
                        Quantity = cart.Quantity
                    }).ToList();
        }

        
    }
}
