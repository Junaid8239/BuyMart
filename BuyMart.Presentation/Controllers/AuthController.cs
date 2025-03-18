using BuyMart.Bll.Interfaces;
using BuyMart.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BuyMart.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace BuyMart.Presentation.Controllers
{
    [Route("Account")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // -------------------- LOGIN --------------------
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_authService.ValidateUser(model.Username, model.Password))
            {
                var user = _authService.GetUserDetailsByUsername(model.Username);

                // Store UserId and Username in Session (instead of Cookies)
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("Username", user.Username);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }


        // -------------------- LOGOUT --------------------
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // -------------------- REGISTER --------------------
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View(model);
            }

            bool isRegistered = _authService.RegisterUser(model.Username, model.Email, model.Password);
            if (!isRegistered)
            {
                ModelState.AddModelError("", "Username already exists.");
                return View(model);
            }

            return RedirectToAction("Login");
        }
    }
}
