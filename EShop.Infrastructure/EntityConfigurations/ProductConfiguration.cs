using EShop.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Infrastructure.EntityConfigurations
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        protected override void BuildConfig(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Price);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }

        protected override string GetTableName()
        {
            return "Products";
        }
        
    }
}
