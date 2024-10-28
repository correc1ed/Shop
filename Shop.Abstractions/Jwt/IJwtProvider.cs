using Shop.Abstractions.Users.Models;

namespace Shop.Abstractions.Jwt;
public interface IJwtProvider
{
    public string GenerateToken(UserDTO userDTO);
}
