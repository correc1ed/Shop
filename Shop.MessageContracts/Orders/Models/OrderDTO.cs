using Shop.Core.Entities;
using Shop.Core.Enums;
using Shop.MessageContracts.Products.Models;
using Shop.MessageContracts.Users.Models;

namespace Shop.MessageContracts.Orders.Models;

public class OrderDTO
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public UserDTO UserDTO { get; set; }

    /// <summary>
    /// Товары
    /// </summary>
    public List<ProductDTO> ProductDTOs { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public UserStatuses StatusDTO { get; set; }

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
