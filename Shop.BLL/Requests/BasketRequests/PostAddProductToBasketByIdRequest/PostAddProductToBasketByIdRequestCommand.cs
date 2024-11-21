using MediatR;

namespace Shop.BLL.Requests.BasketRequests.PostAddProductToBasketByIdRequest;

/// <summary>
/// Команда запроса <see cref="PostAddProductToBasketByIdRequest"/>
/// </summary>
public class PostAddProductToBasketByIdRequestCommand : MessageContracts.Requests.Baskets.Requests.PostAddProductToBasketById.PostAddProductToBasketByIdRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostAddProductToBasketByIdRequestCommand(MessageContracts.Requests.Baskets.Requests.PostAddProductToBasketById.PostAddProductToBasketByIdRequest request)
            : base(request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));
    }
}
