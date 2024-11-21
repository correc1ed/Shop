using MediatR;
using Shop.MessageContracts.Requests.Users.Responses.GetOrderList;

namespace Shop.DataAccess.Requests.UserRequests.GetUserOrderListRequest;
public class GetUserOrderListRequestQuery : IRequest<GetUserOrderListResponse>
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
