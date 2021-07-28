using FruitShop.Domain.Entities;
using FruitShop.Domain.Models;
using System.Collections.Generic;

namespace FruitShop.Domain.Interfaces
{
    public interface IFruitRepository : IRepository<Fruit>
    {
        IEnumerable<Fruit> GetAll();

        (IEnumerable<Fruit> fruits, PageInfo pageInfo) Get(int pageNumber = 1, int pageSize = 20);
    }
}
