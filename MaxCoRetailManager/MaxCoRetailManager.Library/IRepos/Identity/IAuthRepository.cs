using MaxCoRetailManager.Core.Entities;

namespace MaxCoRetailManager.Core.IRepos.Identity;

public interface IAuthRepository
{
    Task<bool> UserExists(string username);
    Task<bool> Register(User user, string password);
    Task<User> Login(string username, string password);
}
