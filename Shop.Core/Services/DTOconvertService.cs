using Shop.Abstractions;
using Shop.Abstractions.Orders.Models;
using Shop.Abstractions.Products.Models;
using Shop.Abstractions.Users.Models;
using Shop.Core.Entities;
using Shop.Core.Enums;

namespace Shop.Core.Services;
public static class DTOconvertService
{
    public static UserDTO ToUserDTO(User user)
    {
        return new UserDTO()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            IsAdministrator = user.IsAdministrator
        };
    }
    public static User ToUser(UserDTO userDTO)
    {
        return new User()
        {
            Id = userDTO.Id,
            Name = userDTO.Name,
            Email = userDTO.Email,
            Password = userDTO.Password,
            IsAdministrator = userDTO.IsAdministrator
        };
    }
    public static OrderDTO ToOrderDTO(Order order)
    {
        return new OrderDTO()
        {
            Id = order.Id,
            UserDTO = ToUserDTO(order.User),
            ProductDTOs = ToProductDTOs(order.Products),
            StatusDTO = ToStatusDTO(order.Status),
            CreatedAt = order.CreatedAt,
            DeliveredDate = order.DeliveredDate
        };
    }
    public static Order ToOrder(OrderDTO orderDTO)
    {
        return new Order()
        {
            Id = orderDTO.Id,
            User = ToUser(orderDTO.UserDTO),
            Products = ToProducts(orderDTO.ProductDTOs),
            Status = ToStatus(orderDTO.StatusDTO),
            CreatedAt = orderDTO.CreatedAt,
            DeliveredDate = orderDTO.DeliveredDate
        };
    }
    public static List<OrderDTO> ToOrderDTOs(List<Order> orders)
    {
        var list = new List<OrderDTO>();

        foreach (var order in orders)
        {
            list.Add(ToOrderDTO(order));
        }

        return list;
    }
    public static List<Order> ToOrders(List<OrderDTO> orderDTOs)
    {
        var list = new List<Order>();

        foreach (var orderDTO in orderDTOs)
        {
            list.Add(ToOrder(orderDTO));
        }

        return list;
    }
    public static ProductDTO ToProductDTO(Product product)
    {
        return new ProductDTO()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CountInStorage = product.CountInStorage,
            Category = product.Category,
        };
    }
    public static Product ToProduct(ProductDTO productDTO)
    {
        return new Product()
        {
            Id = productDTO.Id,
            Name = productDTO.Name,
            Description = productDTO.Description,
            Price = productDTO.Price,
            CountInStorage = productDTO.CountInStorage,
            Category = productDTO.Category,
        };
    }
    public static List<ProductDTO> ToProductDTOs(List<Product> products)
    {
        var list = new List<ProductDTO>();  

        foreach (var product in products)
        {
            list.Add(ToProductDTO(product));
        }

        return list;
    }
    public static List<Product> ToProducts(List<ProductDTO> productDTOs)
    {
        var list = new List<Product>();  

        foreach (var productDTO in productDTOs)
        {
            list.Add(ToProduct(productDTO));
        }

        return list;
    }
    public static StatusDTO ToStatusDTO(Status status)
    {
        return (StatusDTO)(int)status;
    }
    public static Status ToStatus(StatusDTO status)
    {
        return (Status)(int)status;
    }

}
