using BuyMart.Data.Models;
using BuyMart.Data.Repositories.IRepository;
using BuyMart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMart.Bll.Interfaces
{
    public interface IAuthService
    {
        bool ValidateUser(string username, string password);
        bool RegisterUser(string username, string email, string password);
        User GetUserDetailsByUsername(string username);
    }


}
