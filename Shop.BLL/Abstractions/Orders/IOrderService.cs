using Shop.MessageContracts.Orders.Requests.PostOrder;
using Shop.MessageContracts.Orders.Requests.PutOrderStatus;
using Shop.MessageContracts.Orders.Responses.GetOrderInformationById;

namespace Shop.BLL.Abstractions.Orders;
public interface IOrderService
{
    Task<GetOrderInfoByIdResponse> GetOrderInfoByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddOrderAsync(PostOrderRequest request, CancellationToken cancellationToken);
    Task PutUpdateOrderStatusAsync(Guid orderId, PutUpdateOrderStatusRequest request, CancellationToken cancellationToken);
}
