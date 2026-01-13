namespace V1A_DependencyInjection.Core.Model
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
