namespace Shop.Abstractions.Orders.Requests.PutOrderStatus;
public class PutUpdateOrderStatusRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PutUpdateOrderStatusRequest(PutUpdateOrderStatusRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        StatusDTO = request.StatusDTO;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public PutUpdateOrderStatusRequest()
    {
    }

    /// <summary>
    /// Статус
    /// </summary>
    public StatusDTO StatusDTO { get; set; }
}
