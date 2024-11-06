using MediatR;
using Shop.BLL.Abstractions.Orders;

namespace Shop.Requests.OrderRequests.PostOrderRequest;

public class PostOrderRequestCommandHandler : IRequestHandler<PostOrderRequestCommand>
{
    private readonly IOrderService _orderService;

    public PostOrderRequestCommandHandler(
        IOrderService orderService
    )
    {
        _orderService = orderService;
    }
    async Task IRequestHandler<PostOrderRequestCommand>.Handle(PostOrderRequestCommand request, CancellationToken cancellationToken)
    {
        await _orderService.AddOrderAsync(request, cancellationToken);
    }
}
