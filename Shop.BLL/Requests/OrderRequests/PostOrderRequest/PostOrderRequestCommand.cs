using MediatR;

namespace Shop.BLL.Requests.OrderRequests.PostOrderRequest;

/// <summary>
/// Команда запроса <see cref="PostOrderRequest"/>
/// </summary>
public class PostOrderRequestCommand : MessageContracts.Requests.Orders.Requests.PostOrder.PostOrderRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostOrderRequestCommand(MessageContracts.Requests.Orders.Requests.PostOrder.PostOrderRequest request)
            : base(request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));
    }
}
