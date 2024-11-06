using MediatR;
using Shop.BLL.Abstractions.Products;

namespace Shop.Requests.ProductRequests.PostProductRequest;

public class PostProductRequestCommandHandler : IRequestHandler<PostProductRequestCommand>
{
    private readonly IProductService _productService;

    public PostProductRequestCommandHandler(
        IProductService productService
    )
    {
        _productService = productService;
    }
    async Task IRequestHandler<PostProductRequestCommand>.Handle(PostProductRequestCommand request, CancellationToken cancellationToken)
    {
        await _productService.PostAddProductAsync(request, cancellationToken).ConfigureAwait(false);
    }
}