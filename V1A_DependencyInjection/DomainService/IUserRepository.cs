using V1A_DependencyInjection.Model;

namespace V1A_DependencyInjection.DomainService
{
    public interface IUserRepository
    {
        void Add(User user);
        bool IsTaken(string username);
    }
}
