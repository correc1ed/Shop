using Shop.Abstractions.Products.Requests.PostProduct;
using Shop.Abstractions.Products.Requests.PutProduct;

namespace Shop.Abstractions.Products;
public interface IProductService
{
    Task PostAddProductAsync(PostProductRequest request, CancellationToken cancellationToken);
    Task PutUpdateProductInfoAsync(Guid id, PutProductRequest request, CancellationToken cancellationToken);
}
