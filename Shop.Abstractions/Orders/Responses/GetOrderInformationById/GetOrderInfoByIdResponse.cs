using Shop.Abstractions.Products.Models;
using Shop.Abstractions.Users.Models;

namespace Shop.Abstractions.Orders.Responses.GetOrderInformationById;

public class GetOrderListByIdResponse
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
    public StatusDTO StatusDTO { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата доставки
    /// </summary>
    public DateTime DeliveredDate { get; set; }
}
