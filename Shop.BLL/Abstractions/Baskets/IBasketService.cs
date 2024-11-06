using Shop.MessageContracts.Baskets.Requests.PostAddProductToBasketById;

namespace Shop.BLL.Abstractions.Baskets;
public interface IBasketService
{
    Task AddProductAsync(PostAddProductToBasketByIdRequest request, CancellationToken cancellationToken);
    Task DeleteProductByIdAsync(Guid userId, Guid productId, CancellationToken cancellationToken);
}
