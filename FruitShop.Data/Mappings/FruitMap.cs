using FruitShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruitShop.Data.Mappings
{
    public class FruitMap : IEntityTypeConfiguration<Fruit>
    {
        public void Configure(EntityTypeBuilder<Fruit> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Active).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(500);
            builder.Property(a => a.Image).HasMaxLength(500);
            builder.Property(a => a.Stock).IsRequired();
            builder.Property(a => a.Price).HasPrecision(10, 2).IsRequired();
        }
    }
}
