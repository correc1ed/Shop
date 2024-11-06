using Shop.MessageContracts.Users.Models;

namespace Shop.BLL.Abstractions.Jwt;
public interface IJwtProvider
{
    public string GenerateToken(UserDTO userDTO);
}
