using MediatR;
using Shop.BLL.Abstractions.Products;

namespace Shop.Requests.ProductRequests.PutProductRequest;

public class PutProductRequestCommandHandler : IRequestHandler<PutProductRequestCommand>
{
    private readonly IProductService _productService;

    public PutProductRequestCommandHandler(
        IProductService productService
    )
    {
        _productService = productService;
    }
    async Task IRequestHandler<PutProductRequestCommand>.Handle(PutProductRequestCommand request, CancellationToken cancellationToken)
    {
        await _productService.PutUpdateProductInfoAsync(request.Id, request, cancellationToken);
    }
}
