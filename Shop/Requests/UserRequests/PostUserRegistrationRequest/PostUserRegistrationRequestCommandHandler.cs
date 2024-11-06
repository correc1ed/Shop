using MediatR;
using Shop.BLL.Abstractions.Users;

namespace Shop.Requests.UserRequests.PostUserRegistrationRequest;

public class PostUserRegistrationRequestCommandHandler : IRequestHandler<PostUserRegistrationRequestCommand>
{
    private readonly IUserService _userService;

    public PostUserRegistrationRequestCommandHandler(
        IUserService userService
    )
    {
        _userService = userService;
    }
    async Task IRequestHandler<PostUserRegistrationRequestCommand>.Handle(PostUserRegistrationRequestCommand request, CancellationToken cancellationToken)
    {
        await _userService.RegisterAsync(request, cancellationToken);
    }
}