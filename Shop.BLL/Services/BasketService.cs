using Shop.Abstractions.Baskets;
using Shop.Abstractions.Repository;
using Shop.Core.Entities;
using Shop.MessageContracts.Baskets.Models;
using Shop.MessageContracts.Products.Models;
using Shop.MessageContracts.Requests.Baskets.Requests.PostAddProductToBasketById;

namespace Shop.BLL.Services;
public class BasketService : IBasketService
{
    private readonly IBasketRepository _basketRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public BasketService(
        IBasketRepository basketRepository,
        IUserRepository userRepository,
        IProductRepository productRepository)
    {
        _basketRepository = basketRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task AddProductAsync(PostAddProductToBasketByIdRequest request, CancellationToken cancellationToken)
    {
        var basket = await _basketRepository.GetByUserIdAsync(request.UserId, cancellationToken);

        var user = await _userRepository.GetByIdAsync(request.UserId);

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
            basket = new BasketDTO()
            {
                Id = Guid.NewGuid(),
                User = user,
                Products = new List<ProductDTO>(),
                TotalPrice = 0,
                Status = 0
            };
        }
        else
        {
            await _basketRepository.DeleteAsync(basket.Id, cancellationToken);
        }
        await _productRepository.AddAsync(DTOconvertService.ToProductDTO(product));

        await _basketRepository.AddAsync(basket);
    }

    public async Task DeleteProductByIdAsync(Guid userId, Guid productId, CancellationToken cancellationToken)
    {
        await _basketRepository.RemoveProduct(userId, productId);
    }
}
