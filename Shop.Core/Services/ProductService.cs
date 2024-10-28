using Microsoft.EntityFrameworkCore;
using Shop.Abstractions.Products;
using Shop.Abstractions.Products.Requests.PostProduct;
using Shop.Abstractions.Products.Requests.PutProduct;
using Shop.Core.Entities;

namespace Shop.Core.Services;
public class ProductService : IProductService
{
    private readonly EfContext _dbContext;

    public ProductService(
        EfContext db
    )
    {
        _dbContext = db;
    }
    public async Task PostAddProductAsync(PostProductRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var product = Product.Add(request.Name, request.Description, request.Price, request.CountInStorage, request.Category);

        _dbContext.Products.Add(product);

        _dbContext.SaveChanges();
    }
    public async Task PutUpdateProductInfoAsync(Guid id, PutProductRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var product = _dbContext.Products
            .FirstOrDefault(o => o.Id == id);

        if (product == null)
        {
            throw new Exception("Товара с данным идентификатором не существует или вы не правильно его указали");
        }

        _dbContext.Products.Remove(product);
        _dbContext.SaveChanges();

        var updateProduct = new Product
        {
            Id = product.Id,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CountInStorage = request.CountInStorage,
            Category = request.Category
        };

        _dbContext.Products.Add(updateProduct);
        _dbContext.SaveChanges();
    }
}
