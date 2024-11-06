using MediatR;
using Shop.BLL.Abstractions.Baskets;

namespace Shop.Requests.BasketRequests.PostAddProductToBasketByIdRequest;

public class PostAddProductToBasketByIdRequestCommandHandler : IRequestHandler<PostAddProductToBasketByIdRequestCommand>
{
    private readonly IBasketService _basketService;

    public PostAddProductToBasketByIdRequestCommandHandler(
        IBasketService basketService
    )
    {
        _basketService = basketService;
    }

    async Task IRequestHandler<PostAddProductToBasketByIdRequestCommand>.Handle(PostAddProductToBasketByIdRequestCommand request, CancellationToken cancellationToken)
    {
        await _basketService.AddProductAsync(request, cancellationToken).ConfigureAwait(false);
    }
}