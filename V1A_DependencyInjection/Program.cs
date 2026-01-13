using V1A_DependencyInjection;
using V1A_DependencyInjection.Core;
using V1A_DependencyInjection.Core.DomainService;
using V1A_DependencyInjection.Core.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserRepository,InMemoryUserRepository>();
//builder.Services.AddScoped<IUserRepository,SqlUserRepository>();
builder.Services.AddScoped<RegisterService>();
var app = builder.Build();


// In memory database
var userDatabase = new List<User>
{
    new User("terje")
};

app.MapPost("/register", (RegisterRequest req, RegisterService registerService) =>
{
    var registerResponse = registerService.Register(req);

    return registerResponse.Success
        ? Results.Ok(registerResponse)
        : Results.Conflict(registerResponse);
});

app.Run();