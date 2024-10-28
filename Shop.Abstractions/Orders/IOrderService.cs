using Shop.Abstractions.Orders.Requests.GetOrderInformationById;
using Shop.Abstractions.Orders.Requests.PostOrder;
using Shop.Abstractions.Orders.Requests.PutOrderStatus;
using Shop.Abstractions.Orders.Responses.GetOrderInformationById;

namespace Shop.Abstractions.Orders;
public interface IOrderService
{
    Task<GetOrderListByIdResponse> GetOrderListByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddOrderAsync(PostOrderRequest request, CancellationToken cancellationToken);
    Task PutUpdateOrderStatusAsync(Guid orderId, PutUpdateOrderStatusRequest request, CancellationToken cancellationToken);
}
