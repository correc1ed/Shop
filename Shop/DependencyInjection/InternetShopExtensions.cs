using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Abstractions.Baskets;
using Shop.Abstractions.Jwt;
using Shop.Abstractions.Orders;
using Shop.Abstractions.Products;
using Shop.Abstractions.Repository;
using Shop.Abstractions.Users;
using Shop.BLL.Services;
using Shop.BLL.Services.Jwt;
using Shop.DataAccess.Repository;

namespace Shop.DependencyInjection;
public static class InternetShopExtensions
{
    public static IServiceCollection AddInternetShop(this IServiceCollection services)
    {
        services.TryAddScoped<IUserService, UserService>();
        services.TryAddScoped<IOrderService, OrderService>();
        services.TryAddScoped<IBasketService, BasketService>();
        services.TryAddScoped<IProductService, ProductService>();

        services.TryAddScoped<IBasketRepository, BasketRepository>();
        services.TryAddScoped<IOrderRepository, OrderRepository>();
        services.TryAddScoped<IUserRepository, UserRepository>();
        services.TryAddScoped<IProductRepository, ProductRepository>();


        services.TryAddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
}
