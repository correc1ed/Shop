using Shop.MessageContracts.Products.Models;
using Shop.MessageContracts.Users.Models;

namespace Shop.MessageContracts.Orders.Responses.GetOrderInformationById;

public class GetOrderInfoByIdResponse
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
}
