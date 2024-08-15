using MaxCoRetailManager.Application.Responses;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Requests.Queries;

public class GetUserRequest : IRequest<AuthResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
