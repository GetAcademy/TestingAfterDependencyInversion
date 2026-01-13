namespace V1B_DependencyInversionWithoutInterface.Core.Model
{
    public class RegisterRequest
    {
        public string Username { get; }

        public RegisterRequest(string username)
        {
            Username = username;
        }
    }
}
