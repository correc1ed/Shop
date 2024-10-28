namespace Shop.Abstractions.Products.Requests.PutProduct;
public class PutProductRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PutProductRequest(PutProductRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        Name = request.Name;
        Description = request.Description;
        Price = request.Price;
        CountInStorage = request.CountInStorage;
        Category = request.Category;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public PutProductRequest()
    {
    }

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
