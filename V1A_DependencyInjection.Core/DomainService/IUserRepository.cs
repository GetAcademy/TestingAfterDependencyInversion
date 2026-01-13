using V1A_DependencyInjection.Core.Model;

namespace V1A_DependencyInjection.Core.DomainService
{
    public interface IUserRepository
    {
        void Add(User user);
        bool IsTaken(string username);
    }
}
