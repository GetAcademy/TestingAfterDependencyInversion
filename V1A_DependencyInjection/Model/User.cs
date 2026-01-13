namespace V1A_DependencyInjection.Model
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
