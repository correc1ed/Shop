using Shop.MessageContracts.Orders.Models;
using Shop.MessageContracts.Requests.Orders.Responses.GetOrderInformationById;

namespace Shop.Abstractions.Repository;
public interface IOrderRepository : IBaseRepository<OrderDTO>
{
    public Task<GetOrderInfoByIdResponse> GetOrderInfoByIdAsync(Guid id, CancellationToken cancellationToken);
}
