using Shop.Abstractions.Products.Models;
using Shop.Abstractions.Users.Models;

namespace Shop.Abstractions.Orders.Models;
public class OrderViewModel
{
    public Guid Id { get; set; }
    public UserDTO? User { get; set; }
    public List<ProductDTO>? Products { get; set; }
    public StatusDTO Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DeliveredDate { get; set; }

}
