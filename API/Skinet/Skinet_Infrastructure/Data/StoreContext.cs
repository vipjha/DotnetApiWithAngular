using Microsoft.EntityFrameworkCore;
using Skinet_Core.Entities;
using System.Linq;
using System.Reflection;

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFramworkCore.Sqite")
            {
                foreach(var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p=>p.PropertyType == typeof(decimal));
                    foreach(var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
        }

    }
}
