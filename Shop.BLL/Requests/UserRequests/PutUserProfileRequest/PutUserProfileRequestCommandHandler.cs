using MediatR;
using Shop.Abstractions.Users;

namespace Shop.BLL.Requests.UserRequests.PutUserProfileRequest;

public class PutUserProfileRequestCommandHandler : IRequestHandler<PutUserProfileRequestCommand>
{
    private readonly IUserService _userService;

    public PutUserProfileRequestCommandHandler(
        IUserService userService
    )
    {
        _userService = userService;
    }
    async Task IRequestHandler<PutUserProfileRequestCommand>.Handle(PutUserProfileRequestCommand request, CancellationToken cancellationToken)
    {
        await _userService.UpdateUserByIdAsync(request.Id, request, cancellationToken);
    }
}