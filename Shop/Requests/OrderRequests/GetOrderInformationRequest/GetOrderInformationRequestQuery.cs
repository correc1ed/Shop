using MediatR;

namespace Shop.Requests.OrderRequests.GetOrderInformationRequest;

/// <summary>
/// Команда запроса <see cref="GetOrderInformationRequest"/>
/// </summary>
public class GetOrderInformationRequestQuery : IRequest<MessageContracts.Orders.Responses.GetOrderInformationById.GetOrderInfoByIdResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public GetOrderInformationRequestQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}
