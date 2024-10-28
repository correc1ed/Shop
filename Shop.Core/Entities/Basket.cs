using Shop.Core.Enums;

namespace Shop.Core.Entities;

public class Basket
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Товары
    /// </summary>
    public List<Product> Products { get; set; }

    /// <summary>
    /// Полная цена
    /// </summary>
    public decimal TotalPrice { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public Status Status { get; set; }
}
