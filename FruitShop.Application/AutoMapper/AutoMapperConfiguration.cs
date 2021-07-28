using AutoMapper;
using FruitShop.Application.ViewModels;
using FruitShop.Domain.Entities;

namespace FruitShop.Application.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            #region [ ViewModel -> Domain ]

            CreateMap<UserViewModel, User>();
            CreateMap<FruitViewModel, Fruit>();

            #endregion [ ViewModel -> Domain ]

            #region [ Domain -> ViewModel ]

            CreateMap<User, UserViewModel>();
            CreateMap<Fruit, FruitViewModel>();

            #endregion [ Domain -> ViewModel ]
        }
    }
}
