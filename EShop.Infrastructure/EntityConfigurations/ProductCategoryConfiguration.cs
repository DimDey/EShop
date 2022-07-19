using EShop.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Infrastructure.EntityConfigurations
{
    public class ProductCategoryConfiguration : BaseEntityConfiguration<ProductCategory>
    {
        protected override void BuildConfig(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(20).IsRequired();

            builder.HasMany(x => x.Children)
                .WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentId);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }

        protected override string GetTableName()
        {
            return "ProductCategories";
        }
    }
}
