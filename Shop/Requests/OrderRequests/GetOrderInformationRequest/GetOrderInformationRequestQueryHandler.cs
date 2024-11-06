using MediatR;
using Shop.BLL.Abstractions.Orders;
using Shop.MessageContracts.Orders.Responses.GetOrderInformationById;

namespace Shop.Requests.OrderRequests.GetOrderInformationRequest;

public class GetOrderInformationRequestQueryHandler : IRequestHandler<GetOrderInformationRequestQuery, GetOrderInfoByIdResponse>
{
    private readonly IOrderService _orderService;

    public GetOrderInformationRequestQueryHandler(
        IOrderService orderService
    )
    {
        _orderService = orderService;
    }

    public async Task<GetOrderInfoByIdResponse> Handle(GetOrderInformationRequestQuery request, CancellationToken cancellationToken)
    {
        var response = await _orderService.GetOrderInfoByIdAsync(request.Id, cancellationToken);

        return response;
    }
}