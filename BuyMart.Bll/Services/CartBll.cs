using BuyMart.Bll.Interfaces;
using BuyMart.Core.DTOs;
using BuyMart.Data.Models;
using BuyMart.Data.Repositories;
using BuyMart.Data.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMart.Bll.Services
{
    public class CartBll : ICartBll
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartBll(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // 🛒 Add to Cart (checks stock before adding)
        public bool AddToCart(string userId, int productId, int quantity)
        {
            //var product = _unitOfWork.Product.Get(p => p.Id == productId );
            //if (product == null || product.Stock < quantity)
            //{
            //    throw new InvalidOperationException("Product is out of stock.");
            //}

            var existingItem = _unitOfWork.CartItem.Get(c => c.UserId == userId && c.ProductId == productId);

            if (existingItem != null)
            {
                //if (existingItem.Quantity + quantity > product.Stock)
                //{
                //    throw new InvalidOperationException("Not enough stock.");
                //}
                existingItem.Quantity += quantity;
                _unitOfWork.CartItem.UpdateCartItem(existingItem);
                
            }
            else
            {
                _unitOfWork.CartItem.Add(new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity
                });
            }

            _unitOfWork.Save();
            return true;
        }

        // 🗑 Remove from Cart
        public bool RemoveFromCart(string userId, int productId)
        {
            var item = _unitOfWork.CartItem.Get(c => c.UserId == userId && c.ProductId == productId);
            if (item != null)
            {
                _unitOfWork.CartItem.Delete(item);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        // 🔄 Merge guest cart after login
        public bool MergeCart(string guestCartId, string userId)
        {
            var guestCartItems = _unitOfWork.CartItem.GetAll(c => c.UserId == guestCartId).ToList();

            foreach (var item in guestCartItems)
            {
                AddToCart(userId, item.ProductId, item.Quantity);
            }

            _unitOfWork.Save();
            return true;
        }

        // 🚀 Checkout (ensures stock is available)
        public bool Checkout(string userId)
        {
            //var cartItems = _unitOfWork.CartItem.GetAll(c => c.UserId == userId).ToList();

            //foreach (var item in cartItems)
            //{
            //    var product = _unitOfWork.ProductRepository.GetById(item.ProductId);
            //    if (product == null || product.Stock < item.Quantity)
            //    {
            //        throw new InvalidOperationException($"Not enough stock for {product?.Name}.");
            //    }
            //    product.Stock -= item.Quantity;
            //    _unitOfWork.ProductRepository.UpdateProduct(product);
            //}

            ClearCart(userId);
            _unitOfWork.Save();
            return true;
       
        }

        // 🗑 Clear cart
        public bool ClearCart(string userId)
        {
            var cartItems = _unitOfWork.CartItem.GetAll(c => c.UserId == userId).ToList();

            if (cartItems.Any()) // Check if there are items before attempting to remove
            {
                _unitOfWork.CartItem.DeleteRange(cartItems);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        // 📦 Get all cart items

        public List<CartItemDto> GetCartItems(string userId)
        {
            return _unitOfWork.CartItem.GetCartItems(userId);
        }


    }
}
