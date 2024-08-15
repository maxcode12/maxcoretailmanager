using MaxCoRetailManager.Application.Settings;
using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Core.IRepos.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MaxCoRetailManager.Identity.Repos;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<User> _userManager;
    private readonly IOptions<JwtSettings> _jwtSettings;
    private readonly SignInManager<User> _signInManager;

    public AuthRepository(
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        IOptions<JwtSettings> jwtSettings)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtSettings = jwtSettings;

    }
    public async Task<User> Login(string username, string password)
    {
        return null;
    }



    public Task<bool> Register(User user, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserExists(string username)
    {
        var usernameExists = _userManager.FindByNameAsync(username);
        var userEmailExists = _userManager.FindByEmailAsync(username);
        if (usernameExists == null && userEmailExists == null)
        {
            return Task.FromResult(false);
        }
        return Task.FromResult(true);
    }

    private async Task<JwtSecurityToken> GenerateToken(Task<User?> usernameExists)
    {
        var userClaims = await _userManager.GetClaimsAsync(usernameExists.Result);
        var roles = await _userManager.GetRolesAsync(usernameExists.Result);
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, role));
        }
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usernameExists.Result.Id),
            new Claim(ClaimTypes.Name, usernameExists.Result.UserName),
            new Claim(JwtRegisteredClaimNames.Sub, usernameExists.Result.UserName),
            new Claim(ClaimTypes.Surname, usernameExists.Result.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        }.Union(userClaims).Union(roleClaims);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.SecretKey));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Value.Issuer,
            audience: _jwtSettings.Value.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.Value.DurationInMinutes),
            signingCredentials: signingCredentials
        );
        return jwtSecurityToken;
    }
}
