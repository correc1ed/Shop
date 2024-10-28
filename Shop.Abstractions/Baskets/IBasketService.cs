using Shop.Abstractions.Baskets.Requests.DeleteProductFromBasketById;
using Shop.Abstractions.Baskets.Requests.PostAddProductToBasketById;

namespace Shop.Abstractions.Baskets;
public interface IBasketService
{
    Task AddProductAsync(PostAddProductToBasketByIdRequest request, CancellationToken cancellationToken);
    Task DeleteProductByIdAsync(Guid userId, DeleteProductFromBasketByIdRequest request, CancellationToken cancellationToken);
}
