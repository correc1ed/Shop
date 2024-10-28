namespace Shop.Abstractions.Users.Models;
public class UserDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdministrator { get; set; }
}
