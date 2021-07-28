using FruitShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruitShop.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn(1, 1);
            builder.Property(a => a.Active).IsRequired();
            builder.Property(a => a.Admin).IsRequired();
            builder.Property(a => a.Email).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(32).IsRequired();
        }
    }
}
