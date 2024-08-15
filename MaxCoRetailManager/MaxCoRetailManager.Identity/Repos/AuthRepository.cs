using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Features.Users.Queries;
using MaxCoRetailManager.Application.Responses;
using MaxCoRetailManager.Application.Settings;
using MaxCoRetailManager.Core.Entities;
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
    public async Task<AuthResponse> Login(GetUserRequest request)
    {
        var response = new AuthResponse();
        var username = await _userManager.FindByNameAsync(request.Email);
        if (username == null)
        {
            return new AuthResponse { IsSuccess = false, Message = "Invalid Email Address" };
        }

        var result = await _signInManager.CheckPasswordSignInAsync(username, request.Password, false);
        if (result.Succeeded)
        {
            var token = await GenerateToken(Task.FromResult(username));

            return new AuthResponse
            {
                IsSuccess = true,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = username.UserName,
                Email = username.Email,
                Id = username.Id,
                Message = "Login Successful",

            };
        }
        return response;
    }



    public async Task Register(User user, string password)
    {

        var createUser = await _userManager.CreateAsync(user, password);
        if (createUser.Succeeded)
        {
            var token = await _userManager.GetAuthenticatorKeyAsync(user);
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.TwoFactorEnabled = false;
            user.PhoneNumberConfirmed = false;
            var succeeded = _userManager.VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider, token);
            await _userManager.AddToRoleAsync(user, "Admin");

        }

    }

    public Task<bool> UserExists(string username)
    {
        var usernameExists = _userManager.FindByNameAsync(username);

        if (usernameExists == null)
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
