using FruitShop.Domain.Entities;
using FruitShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FruitShop.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SetDefaultValuesOnInsert(this ModelBuilder builder)
        {
            foreach (IMutableEntityType mutableEntityType in builder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in mutableEntityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(BaseEntity.Active):
                            property.IsNullable = false;
                            property.SetDefaultValue(true);
                            break;

                        default:
                            break;
                    }
                }
            }

            return builder;
        }

        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new User() { Id = 1, Active = true, Admin = true, Email = "marco.rabelo@gmail.com", Name = "Admin", Password = "7d985fc7d6ecda46f4abe2dbac6640c4" });

            return builder;
        }
    }
}
