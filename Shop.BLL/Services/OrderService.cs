using Shop.Abstractions.Orders;
using Shop.Abstractions.Repository;
using Shop.Core.Entities;
using Shop.MessageContracts.Orders.Models;
using Shop.MessageContracts.Requests.Orders.Requests.PostOrder;
using Shop.MessageContracts.Requests.Orders.Requests.PutOrderStatus;

namespace Shop.BLL.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(
        IOrderRepository orderRepository
    )
    {
        _orderRepository = orderRepository;
    }
    public async Task AddOrderAsync(PostOrderRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var order = Order.Create(
            DTOconvertService.ToUser(request.UserDTO),
            DTOconvertService.ToProducts(request.ProductDTOs),
            DTOconvertService.ToStatus(request.StatusDTO),
            request.CreatedAt,
            request.DeliveredDate);

        await _orderRepository.AddAsync(DTOconvertService.ToOrderDTO(order));
    }

    public async Task PutUpdateOrderStatusAsync(Guid orderId, PutUpdateOrderStatusRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var order = _orderRepository.GetOrderInfoByIdAsync(orderId, cancellationToken);

        if (order == null)
        {
            throw new Exception("Заказа с данным идентификатором не существует или вы не правильно его указали");
        }

        await _orderRepository.RemoveAsync(order);

        order.StatusDTO = request.StatusDTO;

        await _orderRepository.AddAsync(order);
    }

    OrderDTO IOrderService.GetOrderInfoByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
