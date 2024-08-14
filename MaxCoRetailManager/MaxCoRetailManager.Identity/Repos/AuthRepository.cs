using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Core.IRepos.Identity;
using MaxCoRetailManager.Identity.IdentityContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MaxCoRetailManager.Identity.Repos;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<User> _userManager;
    private readonly IOptions<IConfiguration> config;
    private readonly SignInManager<User> _signInManager;
    private readonly MaxCoRetailIdentityDbContext _context;
    private readonly IConfiguration _config;

    public AuthRepository(MaxCoRetailIdentityDbContext context,
        SignInManager<User> signInManager,
        UserManager<User> userManager, IOptions<IConfiguration> config)
    {
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
        _config = config.Value;

    }
    public Task<User> Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Register(User user, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserExists(string username)
    {
        throw new NotImplementedException();
    }
}
