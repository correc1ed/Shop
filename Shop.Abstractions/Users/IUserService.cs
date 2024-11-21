using Shop.MessageContracts.Requests.Users.Requests.PostUserLogin;
using Shop.MessageContracts.Requests.Users.Requests.PostUserRegistration;
using Shop.MessageContracts.Requests.Users.Requests.PutUserProfile;
using Shop.MessageContracts.Requests.Users.Requests.PutUserProfileForAdmin;

namespace Shop.Abstractions.Users;
public interface IUserService
{
    Task RegisterAsync(PostUserRegistrationRequest request, CancellationToken cancellationToken);
    Task<string> AuthorizeAsync(PostUserLoginRequest request, CancellationToken cancellationToken);
    Task UpdateUserByIdAsync(Guid userId, PutUserProfileRequest request, CancellationToken cancellationToken);
    Task UpdateUserForAdminByIdAsync(Guid userId, PutUserProfileForAdminRequest request, CancellationToken cancellationToken);
}
