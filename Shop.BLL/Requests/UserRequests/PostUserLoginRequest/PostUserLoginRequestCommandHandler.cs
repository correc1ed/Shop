using MediatR;
using Shop.Abstractions.Users;

namespace Shop.BLL.Requests.UserRequests.PostUserLoginRequest;
public class PostUserLoginRequestCommandHandler : IRequestHandler<PostUserLoginRequestCommand>
{
    private readonly IUserService _userService;

    public PostUserLoginRequestCommandHandler(
        IUserService userService
    )
    {
        _userService = userService;
    }
    async Task IRequestHandler<PostUserLoginRequestCommand>.Handle(PostUserLoginRequestCommand request, CancellationToken cancellationToken)
    {
        await _userService.AuthorizeAsync(request, cancellationToken);
    }
}
