using Shop.Core.Enums;

namespace Shop.Core.Entities;

public class Order
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
    /// Статус
    /// </summary>
    public Status Status { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата доставки
    /// </summary>
    public DateTime DeliveredDate { get; set; }

    public static Order Create(User user, List<Product> products, Status status, DateTime createdAt, DateTime deliveredDate)
    {
        return new Order()
        {
            Id = Guid.NewGuid(),
            User = user,
            Products = products,
            Status = status,
            CreatedAt = createdAt,
            DeliveredDate = deliveredDate
        };

    }
}
