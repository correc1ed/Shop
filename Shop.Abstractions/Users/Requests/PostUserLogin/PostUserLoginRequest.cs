namespace Shop.Abstractions.Users.Requests.PostUserLogin;
public class PostUserLoginRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostUserLoginRequest(PostUserLoginRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        Email = request.Email;
        Password = request.Password;
    }
    /// <summary>
    /// Конструктор
    /// </summary>
    public PostUserLoginRequest()
    {
    }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
}
