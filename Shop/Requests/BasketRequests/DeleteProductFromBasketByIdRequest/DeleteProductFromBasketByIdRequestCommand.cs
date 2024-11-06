using MediatR;

namespace Shop.Requests.BasketRequests.DeleteProductFromBasketByIdRequest;

/// <summary>
/// Команда запроса <see cref="DeleteProductFromBasketByIdRequest"/>
/// </summary>
public class DeleteProductFromBasketByIdRequestCommand : IRequest<Unit>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public DeleteProductFromBasketByIdRequestCommand(Guid id, MessageContracts.Baskets.Requests.DeleteProductFromBasketById.DeleteProductFromBasketByIdRequest request)
    {
        Id = id;
        ProductId = request.ProductId;
    }
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
}
