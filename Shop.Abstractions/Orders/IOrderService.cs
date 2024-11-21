using Shop.MessageContracts.Orders.Models;
using Shop.MessageContracts.Requests.Orders.Requests.PostOrder;
using Shop.MessageContracts.Requests.Orders.Requests.PutOrderStatus;

namespace Shop.Abstractions.Orders;
public interface IOrderService
{
    OrderDTO GetOrderInfoByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddOrderAsync(PostOrderRequest request, CancellationToken cancellationToken);
    Task PutUpdateOrderStatusAsync(Guid orderId, PutUpdateOrderStatusRequest request, CancellationToken cancellationToken);
}
