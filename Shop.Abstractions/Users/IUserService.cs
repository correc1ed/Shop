using Shop.Abstractions.Users.Requests.PostUserLogin;
using Shop.Abstractions.Users.Requests.PostUserRegistration;
using Shop.Abstractions.Users.Requests.PutUserProfile;
using Shop.Abstractions.Users.Requests.PutUserProfileForAdmin;
using Shop.Abstractions.Users.Responses.GetOrderList;

namespace Shop.Abstractions.Users;
public interface IUserService
{
    Task RegisterAsync(PostUserRegistrationRequest request, CancellationToken cancellationToken);
    Task<string> AuthorizeAsync(PostUserLoginRequest request, CancellationToken cancellationToken);
    Task<GetUserOrderListResponse> GetOrderListAsync(Guid userId, CancellationToken cancellationToken);
    Task UpdateUserByIdAsync(Guid userId, PutUserProfileRequest request, CancellationToken cancellationToken);
    Task UpdateUserForAdminByIdAsync(Guid userId, PutUserProfileForAdminRequest request, CancellationToken cancellationToken);
}
