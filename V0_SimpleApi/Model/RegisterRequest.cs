namespace V0_SimpleApi.Model
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
