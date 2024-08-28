using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.DTOs.UserDTO;
using MaxCoRetailManager.Application.Features.Users.Requests.Queries;
using MaxCoRetailManager.Application.Responses;
using MaxCoRetailManager.Application.Settings;
using MaxCoRetailManager.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace MaxCoRetailManager.Identity.Repos;

public class AuthRepository : IAuthRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<User> _userManager;
    private readonly JwtSettings _jwtSettings;
    /* private readonly IRolePermissions _rolePermission*/
    private readonly SignInManager<User> _signInManager;


    public AuthRepository(
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        //IRolePermissions rolePermission,
        IOptions<JwtSettings> jwtSettings,

        IHttpContextAccessor httpContextAccessor
        )
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtSettings = jwtSettings.Value;
        _httpContextAccessor = httpContextAccessor;
        //_rolePermission = rolePermission;
    }

    public Guid? GetCurrentUserId()
    {
        Guid? userId = null;
        if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            userId = new Guid(claimsIdentity.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
        }
        return userId;
    }

    public async Task<AuthResponse> GetUserByJwt(string jwt)
    {

        //getting the secret key
        var authResponse = new AuthResponse();
        var token = new MaxCoRetailManager.Application.DTOs.UserDTO.Token();

        //validating the jwt token

        try
        {
            var principal = GetPrincipalFromExpiredToken(jwt);
            if (principal == null)
            {
                return null;
            }
            var claimsIdentity = principal.Identity as ClaimsIdentity;


            var user = await _userManager.FindByNameAsync(claimsIdentity.Name);
            var roles = await _userManager.GetRolesAsync(user);
            string rolestring = roles.Count > 0 ? roles[0] : "NA";
            //var permisson = await _rolePermission.AssignRolesAsync(rolestring);
            //string json = JsonConvert.SerializeObject(permisson.Select(x => new Permission
            //{
            //    Id = x.RoleId,
            //    CreatedBy = x.CreatedBy,
            //}).ToList());
            IEnumerable<Claim> claims = new List<Claim>()
                {
                        new Claim("Photo", user.PhotoUrl ?? ""),
                        new Claim("FullName", user.FirstName + " " + user.LastName)
                        ,new Claim("Role", rolestring)
                    };
            await _signInManager.SignInWithClaimsAsync(user, true, claims);

            token.AccessToken = jwt;
            token.RefreshToken = user.RefreshToken;
            authResponse.Id = user.Id;
            authResponse.Email = user.Email;
            authResponse.FirstName = user.FirstName;
            authResponse.LastName = user.LastName;
            authResponse.UserName = user.UserName;
            authResponse.IsApproved = user.IsApproved;
            authResponse.RoleName = rolestring;
            authResponse.PhoneNumber = user.PhoneNumber;
            authResponse.EmailConfirmed = user.EmailConfirmed;
            authResponse.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            authResponse.PhotoUrl = user.PhotoUrl;
            authResponse.IsSuccess = true;
            authResponse.Message = "User Found";
            authResponse.AccessToken = user.Token;

            user.RefreshToken = authResponse.RefreshToken;
            await _userManager.UpdateAsync(user);

            return authResponse;
        }
        catch (Exception ex)
        {
            //logging the error and returning null
            Console.WriteLine("Error validating JWT token : " + ex.Message);
            return null;
        }

        //returning null if token is not validated
        return null;
    }

    public Task<AuthResponse> GetUserId(string userId)
    {

        var user = _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Task.FromResult(new AuthResponse { IsSuccess = false, Message = "User not found" });
        }
        var roles = _userManager.GetRolesAsync(user.Result);
        string rolestring = roles.Result.Count > 0 ? roles.Result[0] : "NA";
        //var permisson = _rolePermission.AssignRolesAsync(rolestring, "");
        //string json = JsonConvert.SerializeObject(permisson.Result);
        IEnumerable<Claim> claims = new List<Claim>()
                {
                        new Claim("Photo", user.Result.PhotoUrl ?? ""),
                        new Claim("FullName", user.Result.FirstName + " " + user.Result.LastName)
                        ,new Claim("Role",rolestring)
                    };
        _signInManager.SignInWithClaimsAsync(user.Result, true, claims);
        return Task.FromResult(new AuthResponse
        {
            Id = user.Result.Id,
            Email = user.Result.Email,
            FirstName = user.Result.FirstName,
            LastName = user.Result.LastName,
            UserName = user.Result.UserName,
            IsApproved = user.Result.IsApproved,
            RoleName = rolestring,
            PhoneNumber = user.Result.PhoneNumber,
            EmailConfirmed = user.Result.EmailConfirmed,
            PhoneNumberConfirmed = user.Result.PhoneNumberConfirmed,
            PhotoUrl = user.Result.PhotoUrl,
            IsSuccess = true,
            Message = "User Found"
        });

    }

    public UserProfileDto GetUserProfile()
    {
        UserProfileDto userProfile = new UserProfileDto();
        if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            userProfile.Email = claimsIdentity.FindFirst(x => x.Type == ClaimTypes.Email).Value;
            userProfile.UserName = claimsIdentity.FindFirst(x => x.Type == ClaimTypes.Name).Value;
            userProfile.UserId = new(claimsIdentity.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
            userProfile.FirstName = claimsIdentity.FindFirst(x => x.Type == ClaimTypes.GivenName).Value;
            userProfile.LastName = claimsIdentity.FindFirst(x => x.Type == ClaimTypes.Surname).Value;
            userProfile.PhoneNumber = claimsIdentity.FindFirst(x => x.Type == ClaimTypes.MobilePhone).Value;
            userProfile.PhotoUrl = claimsIdentity.FindFirst(x => x.Type == "PhotoUrl").Value;
            userProfile.RoleName = claimsIdentity.FindFirst(x => x.Type == ClaimTypes.Role).Value;
        }
        return userProfile;
    }

    public async Task<AuthResponse> Login(GetUserRequest request)
    {
        var response = new AuthResponse();
        var username = await _userManager.FindByNameAsync(request.Email);
        if (username == null)
        {
            return new AuthResponse { IsSuccess = false, Message = "Invalid Email Address" };
        }
        var roles = await _userManager.GetRolesAsync(username);
        string rolestring = roles.Count > 0 ? roles[0] : "NA";

        var result = await _signInManager.CheckPasswordSignInAsync(username, request.Password, false);
        if (result.Succeeded)
        {
            var token = await GenerateToken(Task.FromResult(username));

            return new AuthResponse
            {
                IsSuccess = true,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = JwtManager.GenerateRefreshToken(username, "Admin", _jwtSettings.SecretKey, _jwtSettings.Issuer, _jwtSettings.Audience),
                UserName = username.UserName,
                Email = username.Email,
                FirstName = username.FirstName,
                LastName = username.LastName,
                PhoneNumber = username.PhoneNumber,
                PhotoUrl = username.PhotoUrl,
                RoleName = rolestring,
                IsApproved = username.IsApproved,
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
            user.TwoFactorEnabled = true;
            user.PhoneNumberConfirmed = true;
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

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials
        );
        return jwtSecurityToken;
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
            ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
        };


        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");



        return principal;

    }
}
