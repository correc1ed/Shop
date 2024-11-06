using System.Text.Json.Serialization;

namespace Shop.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdministrator { get; set; }

    [JsonConstructor]
    public User() { }

    [JsonConstructor]
    public User(string name, string email, string password, bool isAdministrator)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        IsAdministrator = isAdministrator;
    }
}
