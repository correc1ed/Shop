using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.MessageContracts.Products.Requests.PostProduct;
using Shop.MessageContracts.Products.Requests.PutProduct;
using Shop.Requests.ProductRequests.PostProductRequest;
using Shop.Requests.ProductRequests.PutProductRequest;

namespace Shop.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController : ApiControllerBase
{
    /// <summary>
    /// Добавление товара
    /// </summary>
    [HttpPost]
    public async Task Add(
        [FromServices] IMediator mediator,
        [FromBody] PostProductRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new PostProductRequestCommand(request), cancellationToken);
    }

    /// <summary>
    /// Обновление информации о товаре
    /// </summary>
    [HttpPut("{id}")]
    public async Task UpdateInfoById(
        [FromServices] IMediator mediator,
        [FromQuery] Guid id,
        [FromBody] PutProductRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new PutProductRequestCommand(id, request), cancellationToken);
    }
}
