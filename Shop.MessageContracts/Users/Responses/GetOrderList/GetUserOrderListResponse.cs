using Shop.MessageContracts.Orders.Models;

namespace Shop.MessageContracts.Users.Responses.GetOrderList;
public class GetUserOrderListResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public GetUserOrderListResponse()
    { }

    /// <summary>
    /// Список заказов
    /// </summary>
    public List<OrderDTO> OrderDTOs { get; set; }
}
