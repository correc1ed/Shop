using System.Text.Json.Serialization;

namespace Shop.Core.Entities;

public class User
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Признак того, является-ли пользователь администратором.
    /// </summary>
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
