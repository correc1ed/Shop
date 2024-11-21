using MediatR;
using Shop.Abstractions.Repository;
using Shop.MessageContracts.Requests.Users.Responses.GetOrderList;

namespace Shop.DataAccess.Requests.UserRequests.GetUserOrderListRequest;
public class GetUserOrderListRequestQueryHandler : IRequestHandler<GetUserOrderListRequestQuery, GetUserOrderListResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserOrderListRequestQueryHandler(
        IUserRepository userRepository
    )
    {
        _userRepository = userRepository;
    }
    async Task<GetUserOrderListResponse> IRequestHandler<GetUserOrderListRequestQuery, GetUserOrderListResponse>.Handle(GetUserOrderListRequestQuery request, CancellationToken cancellationToken)
    {
        var response = await _userRepository.GetOrderListAsync(request.Id, cancellationToken);

        return response;
    }
}


