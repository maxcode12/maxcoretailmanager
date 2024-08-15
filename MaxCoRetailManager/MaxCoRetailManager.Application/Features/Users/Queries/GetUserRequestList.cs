using MaxCoRetailManager.Application.DTOs.UserDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Queries;

public class GetUserRequestList : IRequest<IReadOnlyList<UserGetDto>>
{
}
