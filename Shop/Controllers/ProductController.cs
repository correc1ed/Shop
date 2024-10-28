using Microsoft.AspNetCore.Mvc;
using Shop.Abstractions.Orders;
using Shop.Abstractions.Products;
using Shop.Abstractions.Products.Requests.PostProduct;
using Shop.Abstractions.Products.Requests.PutProduct;

namespace Shop.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController : ApiControllerBase
{
    private readonly IProductService _productService;

    public ProductController(
        IProductService productService
    )
    {
        _productService = productService;
    }
    /// <summary>
    /// Добавление товара
    /// </summary>
    [HttpPost("PostAddProduct")]
    public Task Add(
        [FromBody] PostProductRequest request,
        CancellationToken cancellationToken)
    {
        _productService.PostAddProductAsync(request, cancellationToken);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Обновление информации о товаре
    /// </summary>
    [HttpPut("PutUpdateProductInfo")]
    public Task UpdateInfoById(
        [FromQuery] Guid id,
        [FromBody] PutProductRequest request,
        CancellationToken cancellationToken)
    {
        _productService.PutUpdateProductInfoAsync(id, request, cancellationToken);
        return Task.CompletedTask;
    }
}
