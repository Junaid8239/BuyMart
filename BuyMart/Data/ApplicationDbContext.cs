using Microsoft.EntityFrameworkCore;

namespace BuyMart.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }




    }
}
