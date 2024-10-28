using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Abstractions.Baskets;
using Shop.Abstractions.Jwt;
using Shop.Abstractions.Orders;
using Shop.Abstractions.Products;
using Shop.Abstractions.Users;
using Shop.Core.Services;
using Shop.Core.Services.Jwt;

namespace Shop.DependencyInjection;
public static class InternetShopExtensions
{
    public static IServiceCollection AddInternetShop(this IServiceCollection services)
    {
        services.TryAddScoped<IUserService, UserService>();
        services.TryAddScoped<IOrderService, OrderService>();
        services.TryAddScoped<IBasketService, BasketService>();
        services.TryAddScoped<IProductService, ProductService>();

        services.TryAddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
}
