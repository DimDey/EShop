using System.Reflection;
using EShop.Infrastructure.EntityConfigurations;
using EShop.Infrastructure.Extentions;
using EShop.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Context
{
    public class EShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public EShopContext(DbContextOptions<EShopContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
