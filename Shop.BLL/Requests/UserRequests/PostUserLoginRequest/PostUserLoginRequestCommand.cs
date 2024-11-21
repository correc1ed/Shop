using MediatR;

namespace Shop.BLL.Requests.UserRequests.PostUserLoginRequest;
public class PostUserLoginRequestCommand : MessageContracts.Requests.Users.Requests.PostUserLogin.PostUserLoginRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostUserLoginRequestCommand(MessageContracts.Requests.Users.Requests.PostUserLogin.PostUserLoginRequest request)
            : base(request) { }
}
