using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MaxCoRetailManager.Identity.Repos;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IReadOnlyList<User>> GetAllUserAsync()
    {
        return await _userManager.Users.ToListAsync();
    }
}
