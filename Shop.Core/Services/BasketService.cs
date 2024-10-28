using Microsoft.EntityFrameworkCore;
using Shop.Abstractions.Baskets;
using Shop.Abstractions.Baskets.Requests.DeleteProductFromBasketById;
using Shop.Abstractions.Baskets.Requests.PostAddProductToBasketById;
using Shop.Core.Entities;

namespace Shop.Core.Services;
public class BasketService : IBasketService
{
    private readonly EfContext _dbContext;

    public BasketService(
        EfContext db
    )
    {
        _dbContext = db;
    }

    public async Task AddProductAsync(PostAddProductToBasketByIdRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var user = _dbContext.Users
            .FirstOrDefault(b => b.Id == request.UserId);

        if (user is null)
            throw new ArgumentNullException(nameof(request));

        var basket = _dbContext.Baskets
                .Include(x => x.User)
                .Include(x => x.Products)
            .FirstOrDefault(b => b.User.Id == request.UserId);

        var product = new Product()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CountInStorage = request.CountInStorage,
            Category = request.Category
        };

        if (basket == null)
        {
            basket = new Basket()
            {
                Id = Guid.NewGuid(),
                User = user,
                Products = new List<Product>(),
                TotalPrice = 0,
                Status = Enums.Status.Processing
            };
        }
        else
        {
            _dbContext.Baskets.Remove(basket);
        }
        basket.Products.Add(product);

        _dbContext.Baskets.Add(basket);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteProductByIdAsync(Guid userId, DeleteProductFromBasketByIdRequest request, CancellationToken cancellationToken)
    {
        var basket = await _dbContext.Baskets
                .Include(x => x.User)
                .Include(x => x.Products)
            .FirstOrDefaultAsync(b => b.User.Id == userId);

        if (basket == null)
        {
            throw new Exception("Корзины с данным идентификатором не существует или вы не правильно его указали");
        }

        var product = basket.Products.FirstOrDefault(p => p.Id == request.ProductId);

        if (product == null)
        {
            throw new Exception("Продукта с данным идентификатором не существует или вы не правильно его указали");
        }
        _dbContext.Baskets.Remove(basket);

        basket.Products.Remove(product);

        _dbContext.Baskets.Add(basket);

        _dbContext.SaveChanges();
    }
}
