using FruitShop.Data.Context;
using FruitShop.Domain.Entities;
using FruitShop.Domain.Interfaces;
using FruitShop.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace FruitShop.Data.Repositories
{
    public class FruitRepository : Repository<Fruit>, IFruitRepository
    {
        public FruitRepository(FruitContext context) : base(context) { }

        public (IEnumerable<Fruit> fruits, PageInfo pageInfo) Get(int pageNumber = 1, int pageSize = 20)
        {
            var results = PagedQuery(a => a.Active, null, pageNumber, pageSize);

            return (results.results.AsEnumerable(), results.pageInfo);
        }

        public IEnumerable<Fruit> GetAll()
        {
            return Query(a => a.Active);
        }
    }
}
