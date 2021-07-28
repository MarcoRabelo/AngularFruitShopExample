using FruitShop.Domain.Entities;
using FruitShop.Domain.Models;
using System.Collections.Generic;

namespace FruitShop.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        (IEnumerable<User> users, PageInfo pageInfo) GetUsers(int pageNumber = 1, int pageSize = 20);
    }
}
