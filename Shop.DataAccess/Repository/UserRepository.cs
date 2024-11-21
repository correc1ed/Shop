using Microsoft.EntityFrameworkCore;
using Shop.Abstractions.Repository;
using Shop.MessageContracts.Requests.Users.Responses.GetOrderList;
using Shop.MessageContracts.Users.Models;

namespace Shop.DataAccess.Repository;
public class UserRepository : IUserRepository
{
    private readonly EfContext _dbContext;
    public UserRepository(
        EfContext db)
    {
        _dbContext = db;
    }
    public async Task<GetUserOrderListResponse> GetOrderListAsync(Guid userId, CancellationToken cancellationToken)
    {
        if (userId == null)
        {
            throw new Exception("Запрос пустой.");
        }
        var orders = _dbContext.Orders
            .Include(u => u.User)
            .Include(p => p.Products)
            .Where(o => o.User.Id == userId).ToList();

        if (orders == null || orders.Count == 0)
        {
            throw new Exception("У пользователя с данным идентификатором отсутствуют заказы");
        }

        return new GetUserOrderListResponse()
        {
            OrderDTOs = DTOconverter.ToOrderDTOs(orders)
        };
    }

    public DbSet<UserDTO> Entities => throw new NotImplementedException();

    public async Task AddAsync(UserDTO entity)
    {
        await _dbContext.Users.AddAsync(DTOconverter.ToUser(entity));
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        var result = await _dbContext.Users
            .ToListAsync();

        return DTOconverter.ToUserDTOs(result);
    }

    public async Task<UserDTO?> GetByIdAsync(Guid id)
    {
        var result = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        return DTOconverter.ToUserDTO(result);
    }

    public async Task RemoveAsync(UserDTO entity)
    {
        _dbContext.Users.Remove(DTOconverter.ToUser(entity));

        await _dbContext.SaveChangesAsync();
    }

    public Task UpdateAsync(UserDTO entity)
    {
        throw new NotImplementedException();
    }
}
