using MaxCoRetailManager.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Application.Features.Users.Requests.Queries;

public class GetUserRequest : IRequest<AuthResponse>
{
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
