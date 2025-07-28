using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreMiniProject.Models
{
    public class CoreMini : IdentityDbContext
    {
        public CoreMini(DbContextOptions options) : base(options)
        {
            //Database.SetCommandTimeout(30000);
        }
        
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Custid = 101, Name = "Sai", Balance = 5000, City = "America", Status = true },
                new Customer { Custid = 102, Name = "Krish", Balance = 3000, City = "Africa", Status = true});
           
        }
    }
}
