namespace Shop.Abstractions.Orders.Requests.GetOrderInformationById;
public class GetOrderInformationByIdRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public GetOrderInformationByIdRequest(GetOrderInformationByIdRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        Id = request.Id;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public GetOrderInformationByIdRequest()
    {
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
}
