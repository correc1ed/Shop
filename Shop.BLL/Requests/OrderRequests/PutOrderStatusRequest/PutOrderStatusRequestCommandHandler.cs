using MediatR;
using Shop.Abstractions.Orders;

namespace Shop.BLL.Requests.OrderRequests.PutOrderStatusRequest;

public class PutOrderStatusRequestCommandHandler : IRequestHandler<PutOrderStatusRequestCommand>
{
    private readonly IOrderService _orderService;

    public PutOrderStatusRequestCommandHandler(
        IOrderService orderService
    )
    {
        _orderService = orderService;
    }
    async Task IRequestHandler<PutOrderStatusRequestCommand>.Handle(PutOrderStatusRequestCommand request, CancellationToken cancellationToken)
    {
        await _orderService.PutUpdateOrderStatusAsync(request.Id, request, cancellationToken);
    }
}