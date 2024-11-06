using MediatR;

namespace Shop.Requests.UserRequests.PostUserLoginRequest;
public class PostUserLoginRequestCommand : MessageContracts.Users.Requests.PostUserLogin.PostUserLoginRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostUserLoginRequestCommand(MessageContracts.Users.Requests.PostUserLogin.PostUserLoginRequest request)
            : base(request) { }
}
