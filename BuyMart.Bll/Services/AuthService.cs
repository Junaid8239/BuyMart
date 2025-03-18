using BuyMart.Bll.Interfaces;
using BuyMart.Data.Models;
using BuyMart.Data.Repositories;
using BuyMart.Data.Repositories.IRepository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BuyMart.Bll.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateUser(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null) return false;

            // Hash the input password using the stored salt
            string hashedInputPassword = HashPassword(password, Convert.FromBase64String(user.Salt));

            // Compare hashed input password with stored password hash
            return user.HashPassword == hashedInputPassword;
        }

        public User GetUserDetailsByUsername(string username)
        {
            return _userRepository.Get(u => u.Username == username);
        }



        public bool RegisterUser(string username, string email, string password)
        {
            // Check if user already exists
            if (_userRepository.GetUserByUsername(username) != null)
            {
                return false; // User already exists
            }

            // Generate salt
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Hash the password with the generated salt
            string hashedPassword = HashPassword(password, salt);

            // Create a new user
            User newUser = new User
            {
                Username = username,
                Email = email,
                HashPassword = hashedPassword,
                Salt = Convert.ToBase64String(salt) // Store salt
            };

            _userRepository.AddUser(newUser);
            return true; // Successfully registered
        }

        private string HashPassword(string password, byte[] salt)
        {
            byte[] hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 32
            );

            return Convert.ToBase64String(hash);
        }
    }

}
