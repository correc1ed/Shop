using MediatR;
using Shop.MessageContracts.Requests.Orders.Responses.GetOrderInformationById;

namespace Shop.DataAccess.Requests.OrderRequests.GetOrderInformationRequest;

/// <summary>
/// Команда запроса <see cref="GetOrderInformationRequest"/>
/// </summary>
public class GetOrderInformationRequestQuery : IRequest<GetOrderInfoByIdResponse>
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
