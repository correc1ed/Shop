namespace Shop.Abstractions.Products.Models;
public class ProductDTO
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Описание товара
    /// </summary>
    public string? Description { get; set; }

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
    public string? Category { get; set; }
}
