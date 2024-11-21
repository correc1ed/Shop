using MediatR;

namespace Shop.BLL.Requests.UserRequests.PutUserProfileForAdminRequest;
public class PutUserProfileForAdminRequestCommand : MessageContracts.Requests.Users.Requests.PutUserProfileForAdmin.PutUserProfileForAdminRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PutUserProfileForAdminRequestCommand(Guid id, MessageContracts.Requests.Users.Requests.PutUserProfileForAdmin.PutUserProfileForAdminRequest request)
    {
        Id = id;
        Name = request.Name;
        Email = request.Email;
        Password = request.Password;
        IsAdministrator = request.IsAdministrator;
    }

    /// <summary>
    /// Идентификатор
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

    /// <summary>
    /// Признак, по которому определяется, является ли данный пользователь администратором
    /// </summary>
    public bool IsAdministrator { get; set; }
}
