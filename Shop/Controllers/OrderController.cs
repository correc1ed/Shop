using Microsoft.AspNetCore.Mvc;
using Shop.Abstractions.Baskets;
using Shop.Abstractions.Orders;
using Shop.Abstractions.Orders.Requests.PostOrder;
using Shop.Abstractions.Orders.Requests.PutOrderStatus;
using Shop.Abstractions.Orders.Responses.GetOrderInformationById;

namespace Shop.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderController : ApiControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(
        IOrderService orderService
    )
    {
        _orderService = orderService;
    }
    /// <summary>
    /// Получение деталей заказа
    /// </summary>
    [HttpGet("GetOrderInformation/{id}")]
    public Task<GetOrderListByIdResponse> GetById(
            [FromQuery] Guid id,
            CancellationToken cancellationToken)
    {
        var result = _orderService.GetOrderListByIdAsync(id, cancellationToken);
        return result;
    }

    /// <summary>
    /// Создание заказа
    /// </summary>
    [HttpPost("PostOrder")]
    public Task AddOrder(
            [FromBody] PostOrderRequest request,
            CancellationToken cancellationToken)
    {
        _orderService.AddOrderAsync(request, cancellationToken);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Изменение статуса заказа
    /// </summary>
    [HttpPut("PutOrderStatus")]
    public Task UpdateOrderStatusById(
            [FromQuery] Guid id,
            [FromBody] PutUpdateOrderStatusRequest request,
            CancellationToken cancellationToken)
    {
        _orderService.PutUpdateOrderStatusAsync(id, request, cancellationToken);
        return Task.CompletedTask;
    }
}
