using Microsoft.EntityFrameworkCore;
using NLayerArchitecture.Core;
using NLayerArchitecture.Repository.Configurations;
using System.Reflection;

namespace NLayerArchitecture.Repository
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            // Real world example
            //var p = new Product() { ProductFeature = new ProductFeature() };
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductFeature>? ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // Tek tek configrationları okuma yöntemi
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
