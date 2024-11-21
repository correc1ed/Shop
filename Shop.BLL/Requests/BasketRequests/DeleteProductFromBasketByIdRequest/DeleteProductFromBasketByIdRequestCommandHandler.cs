using MediatR;
using Shop.Abstractions.Baskets;

namespace Shop.BLL.Requests.BasketRequests.DeleteProductFromBasketByIdRequest;

/// <summary>
/// Обработчик <see cref="DeleteProductFromBasketByIdRequestCommand"/>
/// </summary>
/// 
public class DeleteProductFromBasketByIdRequestCommandHandler : IRequest<DeleteProductFromBasketByIdRequestCommand>
{
    private readonly IBasketService _basketService;

    public DeleteProductFromBasketByIdRequestCommandHandler(
        IBasketService basketService
    )
    {
        _basketService = basketService;
    }

    public async Task Handle(DeleteProductFromBasketByIdRequestCommand request, CancellationToken cancellationToken)
    {
        await _basketService.DeleteProductByIdAsync(request.Id, request.ProductId, cancellationToken);
    }
}
