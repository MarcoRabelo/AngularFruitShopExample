using FruitShop.Data.Context;
using FruitShop.Domain.Entities;
using FruitShop.Domain.Interfaces;
using FruitShop.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace FruitShop.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(FruitContext context) : base(context) { }

        public (IEnumerable<User> users, PageInfo pageInfo) GetUsers(int pageNumber = 1, int pageSize = 20)
        {
            var results = PagedQuery(a => a.Active && !a.Admin, null, pageNumber, pageSize);

            return (results.results.AsEnumerable(), results.pageInfo);
        }
    }
}
