using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Abstractions.Users;
using Shop.Abstractions.Users.Requests.PostUserLogin;
using Shop.Abstractions.Users.Requests.PostUserRegistration;
using Shop.Abstractions.Users.Requests.PutUserProfile;
using Shop.Abstractions.Users.Requests.PutUserProfileForAdmin;
using Shop.Abstractions.Users.Responses.GetOrderList;

namespace Shop.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ApiControllerBase
{
    private readonly IUserService _userService;

    public UserController(
        IUserService userService
    )
    {
        _userService = userService;
    }
    /// <summary>
    /// Получение списка заказов пользователя
    /// </summary>
    [HttpGet("GetOrderList/{id}")]
    //[Authorize]
    public Task<GetUserOrderListResponse> GetById(
            [FromQuery] Guid id,
            CancellationToken cancellationToken)
    {
        var result = _userService.GetOrderListAsync(id, cancellationToken);

        return result;
    }

    /// <summary>
    /// Добавление пользователя (при регистрации)
    /// </summary>
    [HttpPost("PostUserLogin")]
    //[Authorize]
    public Task Authorization(
            [FromBody] PostUserLoginRequest request,
            CancellationToken cancellationToken)
    {
        _userService.AuthorizeAsync(request, cancellationToken);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Добавление пользователя (при регистрации)
    /// </summary>.
    [HttpPost("PostUserRegistration")]
    //[Authorize]
    public Task Register(
            [FromBody] PostUserRegistrationRequest request,
            CancellationToken cancellationToken)
    {
        _userService.RegisterAsync(request, cancellationToken);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Обновление профиля
    /// </summary>
    [HttpPut("PutUpdateUserProfile/{id}")]
    //[Authorize]
    public Task UpdateUserById(
            [FromQuery] Guid id,
            [FromBody] PutUserProfileRequest request,
            CancellationToken cancellationToken)
    {
        _userService.UpdateUserByIdAsync(id, request, cancellationToken);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Обновление профиля от имени администратора
    /// </summary>
    [HttpPut("PutUserProfileForAdmin/{id}")]
    //[Authorize]
    public Task UpdateUserForAdminById(
            [FromQuery] Guid id,
            [FromBody] PutUserProfileForAdminRequest request,
            CancellationToken cancellationToken)
    {
        _userService.UpdateUserForAdminByIdAsync(id, request, cancellationToken);
        return Task.CompletedTask;
    }
}
