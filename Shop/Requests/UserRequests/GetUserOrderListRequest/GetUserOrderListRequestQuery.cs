using MediatR;

namespace Shop.Requests.UserRequests.GetUserOrderListRequest;
public class GetUserOrderListRequestQuery : IRequest<MessageContracts.Users.Responses.GetOrderList.GetUserOrderListResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public GetUserOrderListRequestQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}
