using Microsoft.EntityFrameworkCore;
using Shop.BLL.Requests.BasketRequests.DeleteProductFromBasketByIdRequest;
using Shop.BLL.Requests.BasketRequests.PostAddProductToBasketByIdRequest;
using Shop.BLL.Requests.OrderRequests.PostOrderRequest;
using Shop.BLL.Requests.OrderRequests.PutOrderStatusRequest;
using Shop.BLL.Requests.ProductRequests.PostProductRequest;
using Shop.BLL.Requests.ProductRequests.PutProductRequest;
using Shop.BLL.Requests.UserRequests.PostUserLoginRequest;
using Shop.BLL.Requests.UserRequests.PostUserRegistrationRequest;
using Shop.BLL.Requests.UserRequests.PutUserProfileRequest;
using Shop.BLL.Services.Jwt;
using Shop.DataAccess;
using Shop.DataAccess.Requests.OrderRequests.GetOrderInformationRequest;
using Shop.DependencyInjection;
using System.Reflection;

namespace Shop;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

        builder.Services.AddSwaggerGen();

        builder.Services.AddInternetShop();

        builder.Services.AddDbContext<EfContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.RegisterServicesFromAssembly(typeof(DeleteProductFromBasketByIdRequestCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PostAddProductToBasketByIdRequestCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(GetOrderInformationRequestQuery).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PostOrderRequestCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PutOrderStatusRequestCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PostProductRequestCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PutProductRequestCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PostUserLoginRequestCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PostUserRegistrationRequestCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PutUserProfileRequestCommand).Assembly);
        });

        //builder.Services.AddAuthentication(options =>
        //{
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //}).AddJwtBearer(options =>
        //{
        //    options.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = true,
        //        ValidateIssuerSigningKey = true,
        //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        //        ValidAudience = builder.Configuration["Jwt:Audience"],
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        //    };
        //});

        //builder.Services.AddAuthorization();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        //app.UseAuthentication();

        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
