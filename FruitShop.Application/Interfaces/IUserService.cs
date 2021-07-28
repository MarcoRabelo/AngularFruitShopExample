using FruitShop.Application.ViewModels;
using FruitShop.Application.Wrappers;
using System.Collections.Generic;

namespace FruitShop.Application.Interfaces
{
    public interface IUserService
    {
        PagedResponse<List<UserViewModel>> Get(int pageNumber, int pageSize);

        Response<UserViewModel> GetById(long Id);

        void Insert(UserViewModel userViewModel);

        void Update(UserViewModel userViewModel);

        bool Delete(long Id);

        UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel userAuthenticate);
    }
}
