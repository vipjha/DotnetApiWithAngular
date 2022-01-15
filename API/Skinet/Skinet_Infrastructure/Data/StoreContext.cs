using Microsoft.EntityFrameworkCore;
using Skinet_Core.Entities;



namespace Skinet_Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
       // public DbSet<ProductType> ProductTypes { get; set; } This is change need to upload

    }
}
