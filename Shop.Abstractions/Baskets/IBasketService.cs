using Shop.MessageContracts.Requests.Baskets.Requests.PostAddProductToBasketById;

namespace Shop.Abstractions.Baskets;
public interface IBasketService
{
    Task AddProductAsync(PostAddProductToBasketByIdRequest request, CancellationToken cancellationToken);
    Task DeleteProductByIdAsync(Guid userId, Guid productId, CancellationToken cancellationToken);
}

