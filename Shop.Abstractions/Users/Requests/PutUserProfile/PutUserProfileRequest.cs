namespace Shop.Abstractions.Users.Requests.PutUserProfile;
public class PutUserProfileRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PutUserProfileRequest(PutUserProfileRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        Name = request.Name;
        Email = request.Email;
        Password = request.Password;
    }
    /// <summary>
    /// Конструктор
    /// </summary>
    public PutUserProfileRequest()
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
}
