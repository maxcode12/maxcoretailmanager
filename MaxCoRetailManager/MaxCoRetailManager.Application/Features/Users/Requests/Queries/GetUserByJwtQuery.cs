using MaxCoRetailManager.Application.Responses;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Requests.Queries;

public class GetUserByJwtQuery : IRequest<AuthResponse>
{
    public string Jwt { get; set; }

}

