namespace Shop.Abstractions.Users.Models;
public class UserViewModel
{
    public required Guid Id { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string Name { get; init; }
    public required bool IsAdministrator { get; init; }
}
