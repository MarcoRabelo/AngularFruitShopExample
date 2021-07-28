using FruitShop.Application.Interfaces;
using FruitShop.Application.Services;
using FruitShop.Data.Repositories;
using FruitShop.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FruitShop.IoC
{
    public static class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IFruitService, FruitService>()
                    .AddScoped<IUserService, UserService>();
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IFruitRepository, FruitRepository>()
                    .AddScoped<IUserRepository, UserRepository>();
        }
    }
}
