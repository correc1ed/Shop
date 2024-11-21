using MediatR;
using Shop.Abstractions.Products;

namespace Shop.BLL.Requests.ProductRequests.PostProductRequest;

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