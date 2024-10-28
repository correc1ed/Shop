using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shop.Abstractions.Jwt;
using Shop.Abstractions.Users;
using Shop.Abstractions.Users.Requests.PostUserLogin;
using Shop.Abstractions.Users.Requests.PostUserRegistration;
using Shop.Abstractions.Users.Requests.PutUserProfile;
using Shop.Abstractions.Users.Requests.PutUserProfileForAdmin;
using Shop.Abstractions.Users.Responses.GetOrderList;
using Shop.Core.Entities;

namespace Shop.Core.Services;
public class UserService : IUserService
{
    private readonly EfContext _dbContext;
    private readonly IJwtProvider _jwtProvider;

    public UserService(
        EfContext db,
        IJwtProvider jwtProvider
    )
    {
        _dbContext = db;
        _jwtProvider = jwtProvider;
    }

    public async Task RegisterAsync(PostUserRegistrationRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (request.Password is null)
            throw new ArgumentNullException(nameof(request));

        if (request.Password is null)
            throw new ArgumentNullException(nameof(request));

        var hashedPassword = PasswordEncryptionService.HashPassword(request.Password);

        var user = new User(request.Name, request.Email, hashedPassword, false);
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public async Task<string> AuthorizeAsync(PostUserLoginRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var user = _dbContext.Users.FirstOrDefault(x => x.Email == request.Email);

        if (user == null)
        {
            throw new Exception("Пользователя с данным логином не существует или вы не правильно его указали");
        }

        if (PasswordEncryptionService.VerifyPassword(request.Password, user.Password))
        {
            var token = _jwtProvider.GenerateToken(DTOconvertService.ToUserDTO(user));

            return token;
        }
        else
        {
            throw new Exception("Пароль введён неверно");
        }
    }

    public string GenerateToken(User user)
    {
        return "";
    }

    public async Task<GetUserOrderListResponse> GetOrderListAsync(Guid userId, CancellationToken cancellationToken)
    {
        if (userId == null)
        {
            throw new Exception("Запрос пустой.");
        }
        var orders = _dbContext.Orders
            .Include(u => u.User)
            .Include(p => p.Products)
            .Where(o => o.User.Id == userId).ToList();

        if (orders == null || orders.Count == 0)
        {
            throw new Exception("У пользователя с данным идентификатором отсутствуют заказы");
        }

        return new GetUserOrderListResponse()
        {
            OrderDTOs = DTOconvertService.ToOrderDTOs(orders)
        };
    }

    public async Task UpdateUserByIdAsync(Guid userId, PutUserProfileRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var user = _dbContext.Users
            .FirstOrDefault(o => o.Id == userId);

        if (user == null)
        {
            throw new Exception("Заказа с данным идентификатором не существует или вы не правильно его указали");
        }

        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();

        var hashedPassword = PasswordEncryptionService.HashPassword(request.Password);

        var resultUser = new User()
        {
            Id = user.Id,
            Name = request.Name,
            Email = request.Email,
            Password = hashedPassword
        };

        _dbContext.Users.Add(resultUser);

        _dbContext.SaveChanges();
    }

    public async Task UpdateUserForAdminByIdAsync(Guid userId, PutUserProfileForAdminRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var user = _dbContext.Users
            .FirstOrDefault(o => o.Id == userId);

        if (user == null)
        {
            throw new Exception("Заказа с данным идентификатором не существует или вы не правильно его указали");
        }

        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();

        var hashedPassword = PasswordEncryptionService.HashPassword(request.Password);

        var resultUser = new User()
        {
            Id = user.Id,
            Name = request.Name,
            Email = request.Email,
            Password = hashedPassword,
            IsAdministrator = request.IsAdministrator
        };
        _dbContext.Users.Add(resultUser);

        _dbContext.SaveChanges();
    }
}
