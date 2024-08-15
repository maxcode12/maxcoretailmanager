using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Features.Users.Requests.Queries;
using MaxCoRetailManager.Application.Responses;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Handlers.QueryHandlers;

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
        response.Id = Guid.NewGuid().ToString();
        response.UserName = request.Email;
        response.Email = request.Email;
        response.AccessToken = response.AccessToken;
        response.RefreshToken = response.RefreshToken;

        response.IsSuccess = true;

        return await _authRepository.Login(request);
    }
}
