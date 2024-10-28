namespace Shop.Abstractions.Users.Requests.PutUserProfileForAdmin;
public class PutUserProfileForAdminRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PutUserProfileForAdminRequest(PutUserProfileForAdminRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        Name = request.Name;
        Email = request.Email;
        Password = request.Password;
        IsAdministrator = request.IsAdministrator;
    }
    /// <summary>
    /// Конструктор
    /// </summary>
    public PutUserProfileForAdminRequest()
    {
    }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Признак того, что пользователь является администратором
    /// </summary>
    public bool IsAdministrator { get; set; }
}
