using Shop.Abstractions.Products.Models;
using Shop.Abstractions.Users.Models;

namespace Shop.Abstractions.Orders.Requests.PostOrder;
public class PostOrderRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostOrderRequest(PostOrderRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        UserDTO = request.UserDTO;
        ProductDTOs = request.ProductDTOs;
        UserDTO = request.UserDTO;
        CreatedAt = request.CreatedAt;
        DeliveredDate = request.DeliveredDate;
    }
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
