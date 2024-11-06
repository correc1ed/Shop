using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.BLL.Abstractions.Baskets;
using Shop.BLL.Abstractions.Jwt;
using Shop.BLL.Abstractions.Orders;
using Shop.BLL.Abstractions.Products;
using Shop.BLL.Abstractions.Users;
using Shop.BLL.Services;
using Shop.BLL.Services.Jwt;

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
