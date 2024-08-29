using MaxCoRetailManager.Application.DTOs.UserDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Requests.Queries
{
    public class GetUserProfileQuery : IRequest<UserProfileDto>
    {
    }
}
