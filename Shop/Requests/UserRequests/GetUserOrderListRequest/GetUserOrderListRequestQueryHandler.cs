using MediatR;
using Shop.BLL.Abstractions.Users;
using Shop.MessageContracts.Users.Responses.GetOrderList;

namespace Shop.Requests.UserRequests.GetUserOrderListRequest;
public class GetUserOrderListRequestQueryHandler : IRequestHandler<GetUserOrderListRequestQuery, GetUserOrderListResponse>
{
    private readonly IUserService _userService;

    public GetUserOrderListRequestQueryHandler(
        IUserService userService
    )
    {
        _userService = userService;
    }
    async Task<GetUserOrderListResponse> IRequestHandler<GetUserOrderListRequestQuery, GetUserOrderListResponse>.Handle(GetUserOrderListRequestQuery request, CancellationToken cancellationToken)
    {
        var response = await _userService.GetOrderListAsync(request.Id, cancellationToken);

        return response;
    }
}


