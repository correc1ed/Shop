using Microsoft.EntityFrameworkCore;
using Shop.Abstractions.Repository;
using Shop.MessageContracts.Orders.Models;
using Shop.MessageContracts.Requests.Orders.Responses.GetOrderInformationById;

namespace Shop.DataAccess.Repository;
public class OrderRepository : IOrderRepository
{
    private readonly EfContext _dbContext;
    OrderRepository(
        EfContext db)
    {
        _dbContext = db;
    }

    public DbSet<OrderDTO> Entities => throw new NotImplementedException();

    public async Task AddAsync(OrderDTO entity)
    {
        await _dbContext.Orders.AddAsync(DTOconverter.ToOrder(entity));

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrderDTO>> GetAllAsync()
    {
        var results = await _dbContext.Orders
            .ToListAsync();

        return DTOconverter.ToOrderDTOs(results);
    }

    public async Task<OrderDTO?> GetByIdAsync(Guid id)
    {
        var result = await _dbContext.Orders
            .FirstOrDefaultAsync(o => o.Id == id);

        return DTOconverter.ToOrderDTO(result);
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
            UserDTO = DTOconverter.ToUserDTO(order.User),
            ProductDTOs = DTOconverter.ToProductDTOs(order.Products),
            StatusDTO = DTOconverter.ToStatusDTO(order.Status),
            CreatedAt = order.CreatedAt,
            DeliveredDate = order.DeliveredDate
        };
    }

    public async Task RemoveAsync(OrderDTO entity)
    {
        _dbContext.Orders.Remove(DTOconverter.ToOrder(entity));

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderDTO entity)
    {
        throw new NotImplementedException();
    }
}
