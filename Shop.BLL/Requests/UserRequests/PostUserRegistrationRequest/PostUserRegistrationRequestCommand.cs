using MediatR;

namespace Shop.BLL.Requests.UserRequests.PostUserRegistrationRequest;

/// <summary>
/// Команда запроса <see cref="PostUserRegistrationRequest"/>
/// </summary>
public class PostUserRegistrationRequestCommand : MessageContracts.Requests.Users.Requests.PostUserRegistration.PostUserRegistrationRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostUserRegistrationRequestCommand(MessageContracts.Requests.Users.Requests.PostUserRegistration.PostUserRegistrationRequest request)
            : base(request) { }
}
