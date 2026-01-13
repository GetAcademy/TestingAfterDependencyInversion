using V1B_DependencyInversionWithoutInterface.Core.Model;

namespace V1B_DependencyInversionWithoutInterface.Core
{
    public class RegisterService
    {
        public static RegisterResponse Register(RegisterRequest req, bool isTaken)
        {
            var username = req.Username.Trim();

            if (username.Length < 3)
                return new RegisterResponse(false, "Username must be at least 3 characters.");

            if (isTaken)
                return new RegisterResponse(false, "Username is already taken.");

            var user = new User(username);

            return new RegisterResponse(true, "User registered.", user);
        }
    }
}
