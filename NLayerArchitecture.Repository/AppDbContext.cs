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
            // Oluşturulan tüm configurationı okuyor
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // Tek tek configrationları okuma yöntemi
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id=1,
                Color="Red",
                Height = 100,
                Width = 200,
                ProductId = 1,
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Blue",
                Height = 300,
                Width = 500,
                ProductId = 2,
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
