using V1B_DependencyInversionWithoutInterface.Core;
using V1B_DependencyInversionWithoutInterface.Core.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// In memory database
var userDatabase = new List<User>
{
    new User("terje")
};

app.MapPost("/register", (RegisterRequest req) =>
{
    // 1. IO
    var isTaken = userDatabase.Any(u => u.Username.Equals(req.Username, StringComparison.OrdinalIgnoreCase));

    // 2. Business logikk
    var registerResponse = RegisterService.Register(req, isTaken);

    // 3. IO
    if (registerResponse.UserToBeAdded != null)
    {
        userDatabase.Add(registerResponse.UserToBeAdded);
    }

    // 4. Mer business logikk

    // 5. IO
});

app.Run();


/*

I mer komplekse tilfeller kan du få behov for: 

    // 1. IO
   var isTaken = userDatabase.Any(u => u.Username.Equals(req.Username, StringComparison.OrdinalIgnoreCase));

   // 2. Business logikk
   var registerResponse = RegisterService.Register(req, isTaken);

   // 3. IO
   if (registerResponse.UserToBeAdded != null)
   {
       userDatabase.Add(registerResponse.UserToBeAdded);
   }

   // 4. Mer business logikk

   // 5. IO

Eller noe sånt: 

    while(notFinished) {

        // 1. IO

        // 2. Business logikk

        // 3. IO

    }
 
 */