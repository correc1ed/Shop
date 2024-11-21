using Shop.MessageContracts.Requests.Users.Responses.GetOrderList;
using Shop.MessageContracts.Users.Models;

namespace Shop.Abstractions.Repository;
public interface IUserRepository : IBaseRepository<UserDTO>
{
    public Task<GetUserOrderListResponse> GetOrderListAsync(Guid userId, CancellationToken cancellationToken);
}
