using V0_SimpleApi.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// In memory database
var userDatabase = new List<User>
{
    new User("terje")
};

app.MapPost("/register", (RegisterRequest req) =>
{
    var username = req.Username.Trim();

    if (username.Length < 3)
        return Results.BadRequest(new {error = "Username must be at least 3 characters."});

    var isTaken = userDatabase.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

    if (isTaken)
        return Results.Conflict(new {error = "Username is already taken."});

    var user = new User(username);
    userDatabase.Add(user);

    return Results.Ok(new RegisterResponse(true, "User registered."));
});

app.Run();
