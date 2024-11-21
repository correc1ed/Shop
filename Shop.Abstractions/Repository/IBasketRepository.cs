using Shop.MessageContracts.Baskets.Models;

namespace Shop.Abstractions.Repository;
public interface IBasketRepository : IBaseRepository<BasketDTO>
{
    Task<BasketDTO?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task SaveAsync(BasketDTO basket, CancellationToken cancellationToken);
    Task DeleteAsync(Guid basketId, CancellationToken cancellationToken);
    Task RemoveProduct(Guid productId, Guid userId);
}
