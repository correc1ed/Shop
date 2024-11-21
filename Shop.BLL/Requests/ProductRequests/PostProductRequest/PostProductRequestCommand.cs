using MediatR;

namespace Shop.BLL.Requests.ProductRequests.PostProductRequest;

/// <summary>
/// Команда запроса <see cref="PostProductRequest"/>
/// </summary>
public class PostProductRequestCommand : MessageContracts.Requests.Products.Requests.PostProduct.PostProductRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostProductRequestCommand(MessageContracts.Requests.Products.Requests.PostProduct.PostProductRequest request)
            : base(request) { }
}
