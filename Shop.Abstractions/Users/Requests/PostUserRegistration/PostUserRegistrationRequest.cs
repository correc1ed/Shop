namespace Shop.Abstractions.Users.Requests.PostUserRegistration;
public class PostUserRegistrationRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostUserRegistrationRequest(PostUserRegistrationRequest request)
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
    public PostUserRegistrationRequest()
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
