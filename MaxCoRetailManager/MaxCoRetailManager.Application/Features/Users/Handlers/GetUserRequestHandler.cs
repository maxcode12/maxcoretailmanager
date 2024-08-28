using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Features.Users.Requests.Queries;
using MaxCoRetailManager.Application.Responses;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Handlers;

public class GetUserRequestHandler : IRequestHandler<GetUserRequest, AuthResponse>
{
    private readonly IAuthRepository _authRepository;
    public GetUserRequestHandler(IAuthRepository authRepository)
    {
        _authRepository = authRepository;


    }
    public async Task<AuthResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var response = new AuthResponse();
        var token = new MaxCoRetailManager.Application.DTOs.UserDTO.Token();

        response.Id = Guid.NewGuid().ToString();
        response.UserName = request.Email;
        response.Email = request.Email;
        response.AccessToken = token.AccessToken;
        response.RefreshToken = token.RefreshToken;




        response.IsSuccess = true;

        return await _authRepository.Login(request);
    }
}
