using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shop.BLL.Abstractions.Orders;
using Shop.Core;
using Shop.Core.Entities;
using Shop.MessageContracts.Orders.Requests.PostOrder;
using Shop.MessageContracts.Orders.Requests.PutOrderStatus;
using Shop.MessageContracts.Orders.Responses.GetOrderInformationById;

namespace Shop.BLL.Services;
public class OrderService : IOrderService
{
    private readonly EfContext _dbContext;

    public OrderService(
        EfContext db
    )
    {
        _dbContext = db;
    }

    public async Task<GetOrderInfoByIdResponse> GetOrderInfoByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        /*
         * (id есть, данные в бд есть — а в переменную ничерта не записывается) Наверное очередная глупая ошибка которую я упустил
         * */
        var order = await _dbContext.Orders // вот тут неведомая ошибка.
                .Include(x => x.User)
                .Include(x => x.Products)
                .FirstOrDefaultAsync(o => o.Id == id)
            ;

        if (order == null)
        {
            throw new Exception("Заказа с данным идентификатором не существует или вы не правильно его указали");
        }

        if (order.User == null)
        {
            throw new Exception("Данный заказ не имеет пользователя.");
        }

        if (order.Products == null)
        {
            throw new Exception("Данный заказ не имеет продуктов");
        }

        return new GetOrderInfoByIdResponse()
        {
            Id = order.Id,
            UserDTO = DTOconvertService.ToUserDTO(order.User),
            ProductDTOs = DTOconvertService.ToProductDTOs(order.Products),
            StatusDTO = DTOconvertService.ToStatusDTO(order.Status),
            CreatedAt = order.CreatedAt,
            DeliveredDate = order.DeliveredDate
        };
    }

    public async Task AddOrderAsync(PostOrderRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var order = Order.Create(
            DTOconvertService.ToUser(request.UserDTO),
            DTOconvertService.ToProducts(request.ProductDTOs), 
            DTOconvertService.ToStatus(request.StatusDTO),
            request.CreatedAt,
            request.DeliveredDate);

        _dbContext.Orders.Add(order);

        _dbContext.SaveChanges();
    }

    public async Task PutUpdateOrderStatusAsync(Guid orderId, PutUpdateOrderStatusRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var order = _dbContext.Orders
                .Include(x => x.User)
                .Include(x => x.Products)
            .FirstOrDefault(o => o.Id == orderId);

        if (order == null)
        {
            throw new Exception("Заказа с данным идентификатором не существует или вы не правильно его указали");
        }

        _dbContext.Orders.Remove(order);

        order.Status = DTOconvertService.ToStatus(request.StatusDTO);

        _dbContext.Orders.Add(order);

        _dbContext.SaveChanges();
    }
}
