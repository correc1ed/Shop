using Shop.MessageContracts.Users.Requests.PostUserLogin;
using Shop.MessageContracts.Users.Requests.PostUserRegistration;
using Shop.MessageContracts.Users.Requests.PutUserProfile;
using Shop.MessageContracts.Users.Requests.PutUserProfileForAdmin;
using Shop.MessageContracts.Users.Responses.GetOrderList;

namespace Shop.BLL.Abstractions.Users;
public interface IUserService
{
    Task RegisterAsync(PostUserRegistrationRequest request, CancellationToken cancellationToken);
    Task<string> AuthorizeAsync(PostUserLoginRequest request, CancellationToken cancellationToken);
    Task<GetUserOrderListResponse> GetOrderListAsync(Guid userId, CancellationToken cancellationToken);
    Task UpdateUserByIdAsync(Guid userId, PutUserProfileRequest request, CancellationToken cancellationToken);
    Task UpdateUserForAdminByIdAsync(Guid userId, PutUserProfileForAdminRequest request, CancellationToken cancellationToken);
}
