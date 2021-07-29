using FruitShop.Application.ViewModels;
using FruitShop.Application.Wrappers;
using System.Collections.Generic;

namespace FruitShop.Application.Interfaces
{
    public interface IFruitService
    {
        PagedResponse<List<FruitViewModel>> Get(int pageNumber, int pageSize);

        Response<FruitViewModel> GetById(long Id);

        void Insert(FruitViewModel FruitViewModel);

        void Update(FruitViewModel FruitViewModel);

        bool Delete(long id);

        void AddToCart(FruitToCartViewModel fruitToCart);
    }
}
