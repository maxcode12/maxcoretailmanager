using MaxCoRetailManager.Core.Entities;

namespace MaxCoRetailManager.Application.Contracts.Identity;

public interface IUserRepository
{
    Task<IReadOnlyList<User>> GetAllUserAsync();
}
