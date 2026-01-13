using V1A_DependencyInjection.DomainService;
using V1A_DependencyInjection.Model;

namespace V1A_DependencyInjection
{
    public class RegisterService
    {
        private IUserRepository _userRepository;

        public RegisterService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResult Register(RegisterRequest req)
        {
            var username = req.Username.Trim();

            if (username.Length < 3)
                return Results.BadRequest(new { error = "Username must be at least 3 characters." });

            var isTaken = _userRepository.IsTaken(username);
            //userDatabase.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (isTaken)
                return Results.Conflict(new { error = "Username is already taken." });

            var user = new User(username);
            _userRepository.Add(user);
            //userDatabase.Add(user);

            return Results.Ok(new RegisterResponse(true, "User registered."));
        }
    }
}
