using MediatR;

namespace Shop.Requests.BasketRequests.PostAddProductToBasketByIdRequest;

/// <summary>
/// Команда запроса <see cref="PostAddProductToBasketByIdRequest"/>
/// </summary>
public class PostAddProductToBasketByIdRequestCommand : MessageContracts.Baskets.Requests.PostAddProductToBasketById.PostAddProductToBasketByIdRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostAddProductToBasketByIdRequestCommand(MessageContracts.Baskets.Requests.PostAddProductToBasketById.PostAddProductToBasketByIdRequest request)
            : base(request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));
    }
}
