using Shop.MessageContracts.Products.Requests.PostProduct;
using Shop.MessageContracts.Products.Requests.PutProduct;

namespace Shop.BLL.Abstractions.Products;
public interface IProductService
{
    Task PostAddProductAsync(PostProductRequest request, CancellationToken cancellationToken);
    Task PutUpdateProductInfoAsync(Guid id, PutProductRequest request, CancellationToken cancellationToken);
}
