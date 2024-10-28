namespace Shop.Abstractions.Baskets.Requests.DeleteProductFromBasketById;
public class DeleteProductFromBasketByIdRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public DeleteProductFromBasketByIdRequest(DeleteProductFromBasketByIdRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        ProductId = request.ProductId;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public DeleteProductFromBasketByIdRequest()
    {
    }

    /// <summary>
    /// Идентификатор товара
    /// </summary>

    public Guid ProductId { get; set; }
}
