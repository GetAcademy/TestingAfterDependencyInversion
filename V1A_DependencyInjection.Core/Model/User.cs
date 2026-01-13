namespace V1A_DependencyInjection.Core.Model
{
    public class User
    {
        public string Username { get; }

        public User(string username)
        {
            Username = username;
        }
    }
}
