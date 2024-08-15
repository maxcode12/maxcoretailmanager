using MaxCoRetailManager.Application.DTOs.UserDTO;
using MaxCoRetailManager.Application.Responses;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Commands;

public class CreateUserCommand : IRequest<BaseResponse>
{
    public UserCreateDto UserCreateDto { get; set; } = new UserCreateDto();
}
