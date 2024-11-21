using MediatR;

namespace Shop.BLL.Requests.UserRequests.PutUserProfileRequest;

/// <summary>
/// Команда запроса <see cref="PutUserProfileRequest"/>
/// </summary>
public class PutUserProfileRequestCommand : MessageContracts.Requests.Users.Requests.PutUserProfile.PutUserProfileRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PutUserProfileRequestCommand(Guid id, MessageContracts.Requests.Users.Requests.PutUserProfile.PutUserProfileRequest request)
    {
        Id = id;
        Name = request.Name;
        Email = request.Email;
        Password = request.Password;
    }

    /// <summary>
    /// Идентификаторв
    /// </summary>
    public Guid Id { get; set; }

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
