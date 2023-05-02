using Database.Entites;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class XDbContext : DbContext
    {
        public DbSet<ApplicationUserDb> ApplicationUsers { get; set; }
        public DbSet<CustomerDb> Customers { get; set; }
        public DbSet<OrderDb> Orders { get; set; }
        public DbSet<OrderItemDb> OrderItems { get; set; }
        public DbSet<ProductDb> Products { get; set; }

        public XDbContext(DbContextOptions<XDbContext> options) : base(options)
        { }
    }
}
