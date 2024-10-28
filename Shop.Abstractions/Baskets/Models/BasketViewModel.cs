using Shop.Abstractions.Products.Models;
using Shop.Abstractions.Users.Models;

namespace Shop.Abstractions.Baskets.Models;
public class BasketViewModel
{
    public Guid Id { get; set; }
    public UserDTO User { get; set; }
    public List<ProductDTO> ProductDTOs { get; set; }
    public decimal TotalPrice { get; set; }
    public StatusDTO Status { get; set; }
}
