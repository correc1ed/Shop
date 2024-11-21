using MediatR;
using Shop.BLL.Services;
using Shop.Core.Enums;
using Shop.MessageContracts.Requests.Orders.Requests.PutOrderStatus;

namespace Shop.BLL.Requests.OrderRequests.PutOrderStatusRequest;

/// <summary>
/// Команда запроса <see cref="PutOrderStatusRequest"/>
/// </summary>
public class PutOrderStatusRequestCommand : PutUpdateOrderStatusRequest, IRequest
{

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PutOrderStatusRequestCommand(Guid id, PutUpdateOrderStatusRequest request)
            : base(request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        Id = id;
        Status = DTOconvertService.ToStatus(request.StatusDTO);
    }
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public Status Status { get; set; }

}
