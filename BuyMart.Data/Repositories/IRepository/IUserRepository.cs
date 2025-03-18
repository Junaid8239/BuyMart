using BuyMart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMart.Data.Repositories.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        void AddUser(User user);
    }

}
