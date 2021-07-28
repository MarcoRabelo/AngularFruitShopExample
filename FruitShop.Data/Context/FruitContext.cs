using FruitShop.Data.Extensions;
using FruitShop.Data.Mappings;
using FruitShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitShop.Data.Context
{
    public class FruitContext : DbContext
    {
        public FruitContext(DbContextOptions<FruitContext> options)
            : base(options) { }

        #region [ DBSets ]

        public DbSet<User> Users { get; set; }
        public DbSet<Fruit> Fruits { get; set; }

        #endregion [ DBSets ]

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new FruitMap());
            modelBuilder.SetDefaultValuesOnInsert();
            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
