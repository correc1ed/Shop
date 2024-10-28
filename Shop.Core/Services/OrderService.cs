using Microsoft.EntityFrameworkCore;
using Shop.Abstractions.Orders;
using Shop.Abstractions.Orders.Requests.GetOrderInformationById;
using Shop.Abstractions.Orders.Requests.PostOrder;
using Shop.Abstractions.Orders.Requests.PutOrderStatus;
using Shop.Abstractions.Orders.Responses.GetOrderInformationById;
using Shop.Core.Entities;

namespace Shop.Core.Services;
public class OrderService : IOrderService
{
    private readonly EfContext _dbContext;

    public OrderService(
        EfContext db
    )
    {
        _dbContext = db;
    }

    public async Task<GetOrderListByIdResponse> GetOrderListByIdAsync(Guid id, CancellationToken cancellationToken)
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

        return new GetOrderListByIdResponse()
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

        var order = new Order()
        {
            Id = Guid.NewGuid(),
            User = DTOconvertService.ToUser(request.UserDTO),
            Products = DTOconvertService.ToProducts(request.ProductDTOs),
            Status = DTOconvertService.ToStatus(request.StatusDTO),
            CreatedAt = request.CreatedAt,
            DeliveredDate = request.DeliveredDate
        };

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
