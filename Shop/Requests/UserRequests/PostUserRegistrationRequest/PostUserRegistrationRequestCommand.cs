using MediatR;

namespace Shop.Requests.UserRequests.PostUserRegistrationRequest;

/// <summary>
/// Команда запроса <see cref="PostUserRegistrationRequest"/>
/// </summary>
public class PostUserRegistrationRequestCommand : MessageContracts.Users.Requests.PostUserRegistration.PostUserRegistrationRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostUserRegistrationRequestCommand(MessageContracts.Users.Requests.PostUserRegistration.PostUserRegistrationRequest request)
            : base(request) { }
}
