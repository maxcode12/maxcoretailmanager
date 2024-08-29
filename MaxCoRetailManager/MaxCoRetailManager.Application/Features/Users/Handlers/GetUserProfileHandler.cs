using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.DTOs.UserDTO;
using MaxCoRetailManager.Application.Features.Users.Requests.Queries;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Handlers;

public class GetUserProfileHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto>
{
    private readonly IAuthRepository _authRepo;
    private readonly IMapper _mapper;
    public GetUserProfileHandler(IAuthRepository authRepo, IMapper mapper)
    {
        _authRepo = authRepo;
        _mapper = mapper;
    }
    public async Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var user = _authRepo.GetUserProfile();
        var userProfile = _mapper.Map<UserProfileDto>(user);
        return await Task.FromResult(userProfile);


    }
}
