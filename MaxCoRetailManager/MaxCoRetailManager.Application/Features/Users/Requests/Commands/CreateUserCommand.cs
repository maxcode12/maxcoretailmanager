using MaxCoRetailManager.Application.DTOs.UserDTO;
using MaxCoRetailManager.Application.Responses;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Requests.Commands;

public class CreateUserCommand : IRequest<BaseResponse>
{
    public UserCreateDto UserCreateDto { get; set; } = new UserCreateDto();
}
