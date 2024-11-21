using Shop.Core.Entities;
using Shop.Core.Enums;
using Shop.MessageContracts.Baskets.Models;
using Shop.MessageContracts.Orders.Models;
using Shop.MessageContracts.Products.Models;
using Shop.MessageContracts.Users;
using Shop.MessageContracts.Users.Models;

namespace Shop.DataAccess;
public static class DTOconverter
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
    public static Basket ToBasket(BasketDTO basketDTO)
    {
        return new Basket()
        {
            Id = basketDTO.Id,
            User = ToUser(basketDTO.User),
            Products = ToProducts(basketDTO.Products),
            TotalPrice = basketDTO.TotalPrice,
            Status = ToStatus(basketDTO.Status)
        };
    }
    public static BasketDTO ToBasketDTO(Basket basket)
    {
        return new BasketDTO()
        {
            Id = basket.Id,
            User = ToUserDTO(basket.User),
            Products = ToProductDTOs(basket.Products),
            TotalPrice = basket.TotalPrice,
            Status = ToStatusDTO(basket.Status)
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
    public static List<UserDTO> ToUserDTOs(List<User> users)
    {
        var list = new List<UserDTO>();

        foreach (var user in users)
        {
            list.Add(ToUserDTO(user));
        }

        return list;
    }
    public static List<User> ToUsers(List<UserDTO> userDTOs)
    {
        var list = new List<User>();

        foreach (var userDTO in userDTOs)
        {
            list.Add(ToUser(userDTO));
        }

        return list;
    }
    public static List<BasketDTO> ToBasketDTOs(List<Basket> baskets)
    {
        var list = new List<BasketDTO>();

        foreach (var basket in baskets)
        {
            list.Add(ToBasketDTO(basket));
        }

        return list;
    }
    public static List<Basket> ToBaskets(List<BasketDTO> basketDTOs)
    {
        var list = new List<Basket>();

        foreach (var basketDTO in basketDTOs)
        {
            list.Add(ToBasket(basketDTO));
        }

        return list;
    }
    public static UserStatuses ToStatusDTO(Status status)
    {
        return (UserStatuses)(int)status;
    }
    public static Status ToStatus(UserStatuses status)
    {
        return (Status)(int)status;
    }

}
