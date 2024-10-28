namespace Shop.Abstractions.Baskets.Requests.PostAddProductToBasketById;
public class PostAddProductToBasketByIdRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostAddProductToBasketByIdRequest(PostAddProductToBasketByIdRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        UserId = request.UserId;
        Name = request.Name;
        Description = request.Description;
        Price = request.Price;
        CountInStorage = request.CountInStorage;
        Category = request.Category;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public PostAddProductToBasketByIdRequest()
    {
    }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание товара
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Цена товара
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Количество на складе
    /// </summary>
    public int CountInStorage { get; set; }

    /// <summary>
    /// Категория
    /// </summary>
    public string Category { get; set; }
}
