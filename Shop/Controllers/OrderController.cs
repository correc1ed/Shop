using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.MessageContracts.Orders.Requests.PostOrder;
using Shop.MessageContracts.Orders.Requests.PutOrderStatus;
using Shop.MessageContracts.Orders.Responses.GetOrderInformationById;
using Shop.Requests.OrderRequests.GetOrderInformationRequest;
using Shop.Requests.OrderRequests.PostOrderRequest;
using Shop.Requests.OrderRequests.PutOrderStatusRequest;

namespace Shop.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderController : ApiControllerBase
{
    /// <summary>
    /// Получение деталей заказа
    /// </summary>
    [HttpGet("{id}")]
    public async Task<GetOrderInfoByIdResponse> GetById(
            [FromServices] IMediator mediator,
            [FromQuery] Guid id,
            CancellationToken cancellationToken) => await mediator.Send(new GetOrderInformationRequestQuery(id), cancellationToken);

    /// <summary>
    /// Создание заказа
    /// </summary>
    [HttpPost]
    public async Task AddOrder(
            [FromServices] IMediator mediator,
            [FromBody] PostOrderRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PostOrderRequestCommand(request), cancellationToken);
    }

    /// <summary>
    /// Изменение статуса заказа
    /// </summary>
    [HttpPut("{id}")]
    public async Task UpdateOrderStatusById(
            [FromServices] IMediator mediator,
            [FromQuery] Guid id,
            [FromBody] PutUpdateOrderStatusRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PutOrderStatusRequestCommand(id, request), cancellationToken);
    }
}
