using Shop.MessageContracts.Requests.Products.Requests.PostProduct;
using Shop.MessageContracts.Requests.Products.Requests.PutProduct;

namespace Shop.Abstractions.Products;
public interface IProductService
{
    Task PostAddProductAsync(PostProductRequest request, CancellationToken cancellationToken);
    Task PutUpdateProductInfoAsync(Guid id, PutProductRequest request, CancellationToken cancellationToken);
}
