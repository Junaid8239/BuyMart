using BuyMart.Data.Models;
using BuyMart.Data.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMart.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public User GetUserByUsername(string username)
        {
            return _db.Users.FirstOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();  
        }
    }

}
