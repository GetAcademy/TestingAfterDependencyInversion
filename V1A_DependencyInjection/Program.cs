using V1A_DependencyInjection;
using V1A_DependencyInjection.DomainService;
using V1A_DependencyInjection.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserRepository,InMemoryUserRepository>();
//builder.Services.AddScoped<IUserRepository,SqlUserRepository>();
builder.Services.AddScoped<RegisterService>();
var app = builder.Build();

app.MapPost("/register", (RegisterRequest req, RegisterService registerService) =>
{
    return registerService.Register(req);
});

app.Run();