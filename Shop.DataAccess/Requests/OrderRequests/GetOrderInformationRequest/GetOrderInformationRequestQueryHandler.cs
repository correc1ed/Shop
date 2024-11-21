using MediatR;
using Shop.Abstractions.Repository;
using Shop.MessageContracts.Requests.Orders.Responses.GetOrderInformationById;

namespace Shop.DataAccess.Requests.OrderRequests.GetOrderInformationRequest;

public class GetOrderInformationRequestQueryHandler : IRequestHandler<GetOrderInformationRequestQuery, GetOrderInfoByIdResponse>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderInformationRequestQueryHandler(
        IOrderRepository orderRepository
    )
    {
        _orderRepository = orderRepository;
    }

    public async Task<GetOrderInfoByIdResponse> Handle(GetOrderInformationRequestQuery request, CancellationToken cancellationToken)
    {
        var response = await _orderRepository.GetOrderInfoByIdAsync(request.Id, cancellationToken);

        return response;
    }
}