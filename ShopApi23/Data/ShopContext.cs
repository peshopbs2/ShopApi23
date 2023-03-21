using Microsoft.EntityFrameworkCore;

namespace ShopApi23.Data
{
    public class ShopContext : DbContext
    {

        public ShopContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
