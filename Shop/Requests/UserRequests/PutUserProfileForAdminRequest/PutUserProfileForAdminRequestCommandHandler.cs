using MediatR;
using Shop.BLL.Abstractions.Users;

namespace Shop.Requests.UserRequests.PutUserProfileForAdminRequest;
public class PutUserProfileForAdminRequestCommandHandler : IRequestHandler<PutUserProfileForAdminRequestCommand>
{
    private readonly IUserService _userService;

    public PutUserProfileForAdminRequestCommandHandler(
        IUserService userService
    )
    {
        _userService = userService;
    }
    public async Task Handle(PutUserProfileForAdminRequestCommand request, CancellationToken cancellationToken)
    {
        await _userService.UpdateUserForAdminByIdAsync(request.Id, request, cancellationToken);
    }
}
