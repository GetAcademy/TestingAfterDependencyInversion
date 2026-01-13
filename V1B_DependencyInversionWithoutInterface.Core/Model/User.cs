namespace V1B_DependencyInversionWithoutInterface.Core.Model
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
