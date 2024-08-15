using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.DTOs.UserDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Queries;

public class GetUserRequestListHandler : IRequestHandler<GetUserRequestList, IReadOnlyList<UserGetDto>>
{
    private readonly IUserRepository _user;
    private readonly IMapper _mapper;

    public GetUserRequestListHandler(IUserRepository user,
        IMapper mapper)
    {
        _user = user;
        _mapper = mapper;
    }
    public async Task<IReadOnlyList<UserGetDto>> Handle(GetUserRequestList request, CancellationToken cancellationToken)
    {
        var users = await _user.GetAllUserAsync();
        return _mapper.Map<IReadOnlyList<UserGetDto>>(users);
    }
}
