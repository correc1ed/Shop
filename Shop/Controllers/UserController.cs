using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.MessageContracts.Users.Requests.PostUserLogin;
using Shop.MessageContracts.Users.Requests.PostUserRegistration;
using Shop.MessageContracts.Users.Requests.PutUserProfile;
using Shop.MessageContracts.Users.Requests.PutUserProfileForAdmin;
using Shop.MessageContracts.Users.Responses.GetOrderList;
using Shop.Requests.UserRequests.GetUserOrderListRequest;
using Shop.Requests.UserRequests.PostUserLoginRequest;
using Shop.Requests.UserRequests.PostUserRegistrationRequest;
using Shop.Requests.UserRequests.PutUserProfileForAdminRequest;
using Shop.Requests.UserRequests.PutUserProfileRequest;

namespace Shop.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ApiControllerBase
{
    /// <summary>
    /// Получение списка заказов пользователя
    /// </summary>
    [HttpGet("{id}")]
    //[Authorize]
    public async Task<GetUserOrderListResponse> GetById(
            [FromServices] IMediator mediator,
            [FromQuery] Guid id,
            CancellationToken cancellationToken) => await mediator.Send(new GetUserOrderListRequestQuery(id), cancellationToken);

    /// <summary>
    /// Добавление пользователя (при регистрации)
    /// </summary>
    [HttpPost("auth/")]
    //[Authorize]
    public async Task Authorization(
            [FromServices] IMediator mediator,
            [FromBody] PostUserLoginRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PostUserLoginRequestCommand(request), cancellationToken);
    }

    /// <summary>
    /// Добавление пользователя (при регистрации)
    /// </summary>.
    [HttpPost("register/")]
    //[Authorize]
    public async Task Register(
            [FromServices] IMediator mediator,
            [FromBody] PostUserRegistrationRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PostUserRegistrationRequestCommand(request), cancellationToken);
    }

    /// <summary>
    /// Обновление профиля
    /// </summary>
    [HttpPut("forUser/{id}")]
    //[Authorize]
    public async Task UpdateUserById(
            [FromServices] IMediator mediator,
            [FromQuery] Guid id,
            [FromBody] PutUserProfileRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PutUserProfileRequestCommand(id, request), cancellationToken);
    }

    /// <summary>
    /// Обновление профиля от имени администратора
    /// </summary>
    [HttpPut("forAdmin/{id}")]
    //[Authorize]
    public async Task UpdateUserForAdminById(
            [FromServices] IMediator mediator,
            [FromQuery] Guid id,
            [FromBody] PutUserProfileForAdminRequest request,
            CancellationToken cancellationToken)
    {
        await mediator.Send(new PutUserProfileForAdminRequestCommand(id, request), cancellationToken);
    }
}
