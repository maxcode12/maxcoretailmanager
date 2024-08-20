using MaxCoRetailManager.Application.DTOs.UserDTO;
using MaxCoRetailManager.Application.Features.Users.Requests.Queries;
using MaxCoRetailManager.Application.Responses;
using MaxCoRetailManager.Core.Entities;

namespace MaxCoRetailManager.Application.Contracts.Identity;
public interface IAuthRepository
{
    Task<bool> UserExists(string username);
    Task Register(User user, string password);
    Task<AuthResponse> Login(GetUserRequest query);
    public Guid? GetCurrentUserId();
    public UserProfileDto GetUserProfile();

}
