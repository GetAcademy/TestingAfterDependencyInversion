using V1A_DependencyInjection.DomainService;
using V1A_DependencyInjection.Model;

namespace V1A_DependencyInjection
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User> _userDatabase;

        public InMemoryUserRepository()
        {
            _userDatabase = new List<User>
            {
                new User("terje")
            };
        }

        public void Add(User user)
        {
            _userDatabase.Add(user);
        }

        public bool IsTaken(string username)
        {
            return _userDatabase.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
