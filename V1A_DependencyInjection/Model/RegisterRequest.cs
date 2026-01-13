namespace V1A_DependencyInjection.Model
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
