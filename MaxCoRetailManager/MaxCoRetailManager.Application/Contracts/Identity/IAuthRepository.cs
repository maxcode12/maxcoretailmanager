using MaxCoRetailManager.Application.Features.Users.Requests.Queries;
using MaxCoRetailManager.Application.Responses;
using MaxCoRetailManager.Core.Entities;

namespace MaxCoRetailManager.Application.Contracts.Identity;
public interface IAuthRepository
{
    Task<bool> UserExists(string username);
    Task<bool> Register(User user, string password);
    Task<AuthResponse> Login(GetUserRequest query);
}
