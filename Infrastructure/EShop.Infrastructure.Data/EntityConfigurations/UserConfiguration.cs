using EShop.Domain.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Infrastructure.Data.EntityConfigurations
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        protected override void BuildConfig(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordSalt).IsRequired();
        }

        protected override string GetTableName()
        {
            return "Users";
        }
    }
}

