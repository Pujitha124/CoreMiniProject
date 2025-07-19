using Microsoft.EntityFrameworkCore;

namespace CoreMiniProject.Models
{
    public class CoreMini : DbContext
    {
        public CoreMini(DbContextOptions options) : base(options)
        {
            //Database.SetCommandTimeout(30000);
        }
        
        public DbSet<Customer> Customers { get; set; }
    }
}
