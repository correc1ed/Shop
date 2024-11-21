using Shop.MessageContracts.Products.Models;
using Shop.MessageContracts.Users;
using Shop.MessageContracts.Users.Models;

namespace Shop.MessageContracts.Baskets.Models;
public class BasketDTO
{

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public UserDTO User { get; set; }

    /// <summary>
    /// Товары
    /// </summary>
    public List<ProductDTO> Products { get; set; }

    /// <summary>
    /// Полная цена
    /// </summary>
    public decimal TotalPrice { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public UserStatuses Status { get; set; }
}
