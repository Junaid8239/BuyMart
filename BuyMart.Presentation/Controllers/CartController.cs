using Microsoft.AspNetCore.Mvc;
using BuyMart.Bll.Interfaces;
using BuyMart.Presentation.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace BuyMart.Presentation.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartBll _cartBll;
        private const string GuestCartSessionKey = "GuestCart"; // Session key for guest cart

        public CartController(ICartBll cartBll)
        {
            _cartBll = cartBll;
        }

      
        private string GetUserId()
        {
            return HttpContext.Session.GetString("UserId");
        }

        
        public IActionResult Index()
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                var guestCart = GetGuestCart();
                return View(guestCart);
            }
            else
            {
                // Logged-in User → Get cart from Database
                var cartItems = _cartBll.GetCartItems(userId);

                // Convert List<CartItem> to List<CartItemViewModel>
                var cartViewModels = cartItems.Select(c => new CartItemViewModel
                {
                    ProductId = c.ProductId,
                    ProductName = c.ProductName ?? "Unknown",
                    Price = c.Price,
                    Quantity = c.Quantity
                }).ToList();

                return View(cartViewModels);
            }
        }

        
        [HttpPost]
        public IActionResult AddToCart(int productId, string productName, decimal price, int quantity)
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                // Guest User → Store in Session
                AddToGuestCart(productId, productName, price, quantity);
            }
            else
            {
                // Logged-in User → Store in Database
                _cartBll.AddToCart(userId, productId, quantity);
            }

            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                // Guest User → Remove from Session
                RemoveFromGuestCart(productId);
            }
            else
            {
                // Logged-in User → Remove from Database
                _cartBll.RemoveFromCart(userId, productId);
            }

            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public IActionResult ClearCart()
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                // Guest User → Clear Session
                HttpContext.Session.Remove(GuestCartSessionKey);
            }
            else
            {
                // Logged-in User → Clear Database Cart
                _cartBll.ClearCart(userId);
            }

            return RedirectToAction("Index");
        }

       
        public IActionResult MergeCart()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId)) return RedirectToAction("Login", "Account");

            var guestCart = GetGuestCart();
            foreach (var item in guestCart)
            {
                _cartBll.AddToCart(userId, item.ProductId, item.Quantity);
            }

            HttpContext.Session.Remove(GuestCartSessionKey); // Clear guest cart after merge

            return RedirectToAction("Index");
        }

        #region Guest Cart (Session Storage)

      
        private List<CartItemViewModel> GetGuestCart()
        {
            var cartJson = HttpContext.Session.GetString(GuestCartSessionKey);
            return string.IsNullOrEmpty(cartJson)
                ? new List<CartItemViewModel>()
                : JsonConvert.DeserializeObject<List<CartItemViewModel>>(cartJson) ?? new List<CartItemViewModel>();
        }

        /// <summary>
        /// Adds an item to the guest cart (Session-based)
        /// </summary>
        private void AddToGuestCart(int productId, string productName, decimal price, int quantity)
        {
            var cart = GetGuestCart();
            var existingItem = cart.Find(i => i.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItemViewModel
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity
                });
            }

            HttpContext.Session.SetString(GuestCartSessionKey, JsonConvert.SerializeObject(cart));
        }

        /// <summary>
        /// Removes an item from the guest cart
        /// </summary>
        private void RemoveFromGuestCart(int productId)
        {
            var cart = GetGuestCart();
            var item = cart.Find(i => i.ProductId == productId);

            if (item != null)
            {
                cart.Remove(item);
            }

            HttpContext.Session.SetString(GuestCartSessionKey, JsonConvert.SerializeObject(cart));
        }

        #endregion
    }
}
