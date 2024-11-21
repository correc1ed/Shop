using Microsoft.EntityFrameworkCore;
using Shop.Abstractions.Repository;
using Shop.MessageContracts.Baskets.Models;

namespace Shop.DataAccess.Repository;
public class BasketRepository : IBasketRepository
{
    private readonly EfContext _dbContext;

    public DbSet<BasketDTO> Entities => throw new NotImplementedException();

    public BasketRepository(EfContext context)
    {
        _dbContext = context;
    }

    public async Task DeleteAsync(Guid basketId, CancellationToken cancellationToken)
    {
        var basketEntity = await _dbContext.Baskets
            .FirstOrDefaultAsync(b => b.Id == basketId, cancellationToken);

        if (basketEntity is not null)
        {
            _dbContext.Baskets.Remove(basketEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    async Task<BasketDTO?> IBasketRepository.GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var basket = await _dbContext.Baskets
            .Include(b => b.Products)
            .FirstOrDefaultAsync(b => b.User.Id == userId, cancellationToken);

        return basket is null ? null : DTOconverter.ToBasketDTO(basket);
    }

    public async Task SaveAsync(BasketDTO basketDto, CancellationToken cancellationToken)
    {
        var basketEntity = await _dbContext.Baskets
            .FirstOrDefaultAsync(b => b.Id == basketDto.Id, cancellationToken);

        if (basketEntity is null)
        {
            basketEntity = DTOconverter.ToBasket(basketDto);
            await _dbContext.Baskets.AddAsync(basketEntity, cancellationToken);
        }
        else
        {
            _dbContext.Entry(basketEntity).CurrentValues.SetValues(DTOconverter.ToBasket(basketDto));
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    public async Task RemoveProduct(Guid productId, Guid userId)
    {
        var basket = await _dbContext.Baskets
            .Include(p => p.Products)
            .FirstOrDefaultAsync(b => b.User.Id == userId);

        if (basket is null)
            throw new ArgumentNullException(nameof(basket));

        var product = await _dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product is null)
            throw new ArgumentNullException(nameof(product));

        basket.Products.Remove(product);

        await _dbContext.SaveChangesAsync();
    }
    public Task UpdateAsync(BasketDTO entity)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<BasketDTO>> GetAllAsync()
    {
        var result = await _dbContext.Baskets.ToListAsync();

        return DTOconverter.ToBasketDTOs(result);
    }

    public async Task AddAsync(BasketDTO entity)
    {
        await _dbContext.Baskets.AddAsync(DTOconverter.ToBasket(entity));

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(BasketDTO entity)
    {
        _dbContext.Baskets.Remove(DTOconverter.ToBasket(entity));

        await _dbContext.SaveChangesAsync();
    }

    public async Task<BasketDTO?> GetByIdAsync(Guid id)
    {
        var basket = await _dbContext.Baskets
            .FirstOrDefaultAsync(b => b.Id == id);

        return DTOconverter.ToBasketDTO(basket);
    }
}
