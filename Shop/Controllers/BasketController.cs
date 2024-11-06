using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.MessageContracts.Baskets.Requests.DeleteProductFromBasketById;
using Shop.MessageContracts.Baskets.Requests.PostAddProductToBasketById;
using Shop.Requests.BasketRequests.DeleteProductFromBasketByIdRequest;
using Shop.Requests.BasketRequests.PostAddProductToBasketByIdRequest;

namespace Shop.Controllers;
[ApiController]
[Route("[controller]")]
public class BasketController : ApiControllerBase
{
    /// <summary>
    /// Добавление товара в корзину
    /// </summary>
    [HttpPost]
    public async Task AddProduct(
            [FromServices] IMediator mediator,
            [FromBody] PostAddProductToBasketByIdRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PostAddProductToBasketByIdRequestCommand(request), cancellationToken);
    }

    /// <summary>
    /// Удаление товара из корзины
    /// </summary>
    [HttpDelete("{id}")]
    public async Task DeleteProductById(
            [FromServices] IMediator mediator,
            [FromBody] DeleteProductFromBasketByIdRequest request,
            [FromQuery] Guid id,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteProductFromBasketByIdRequestCommand(id, request), cancellationToken);
    }
}
