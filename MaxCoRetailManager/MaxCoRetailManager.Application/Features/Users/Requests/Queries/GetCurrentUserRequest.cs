using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Requests.Queries;

public class GetCurrentUserRequest : IRequest<Guid?>
{
}
