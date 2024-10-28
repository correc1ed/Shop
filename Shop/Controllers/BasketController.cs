using Microsoft.AspNetCore.Mvc;
using Shop.Abstractions.Baskets;
using Shop.Abstractions.Baskets.Requests.DeleteProductFromBasketById;
using Shop.Abstractions.Baskets.Requests.PostAddProductToBasketById;

namespace Shop.Controllers;
[ApiController]
[Route("[controller]")]
public class BasketController : ApiControllerBase
{
    private readonly IBasketService _basketService;

    public BasketController(
        IBasketService basketService
    )
    {
        _basketService = basketService;
    }

    /// <summary>
    /// Добавление товара в корзину
    /// </summary>
    [HttpPost("PostProductToBasket")]
    public Task AddProduct(
            [FromBody] PostAddProductToBasketByIdRequest request,
            CancellationToken cancellationToken)
    {
        _basketService.AddProductAsync(request, cancellationToken);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Удаление товара из корзины
    /// </summary>
    [HttpDelete("DeleteProductFromBasket")]
    public Task DeleteProductById(
            [FromBody] DeleteProductFromBasketByIdRequest request,
            [FromQuery] Guid id,
            CancellationToken cancellationToken)
    {
        _basketService.DeleteProductByIdAsync(id, request, cancellationToken);
        return Task.CompletedTask;
    }
}
