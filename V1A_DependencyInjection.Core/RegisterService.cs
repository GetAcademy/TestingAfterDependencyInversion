using V1A_DependencyInjection.Core.DomainService;
using V1A_DependencyInjection.Core.Model;

namespace V1A_DependencyInjection.Core
{
    public class RegisterService
    {
        private readonly IUserRepository _userRepository;

        public RegisterService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public RegisterResponse Register(RegisterRequest req)
        {
            var username = req.Username.Trim();

            if (username.Length < 3)
                return new RegisterResponse(false, "Username must be at least 3 characters.");

            var isTaken = _userRepository.IsTaken(username);
            //userDatabase.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (isTaken)
                return new RegisterResponse(false, "Username is already taken.");

            var user = new User(username);
            _userRepository.Add(user);
            //userDatabase.Add(user);

            return new RegisterResponse(true, "User registered.");
        }
    }
}
