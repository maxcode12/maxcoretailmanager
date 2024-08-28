using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Features.Users.Requests.Queries;
using MaxCoRetailManager.Application.Responses;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Handlers;

public class GetUserByJwtHandler : IRequestHandler<GetUserByJwtQuery, AuthResponse>
{
    private readonly IAuthRepository _authRepository;
    public GetUserByJwtHandler(IAuthRepository authRepository)
    {
        _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
    }

    public async Task<AuthResponse> Handle(GetUserByJwtQuery request, CancellationToken cancellationToken)
    {
        var response = new AuthResponse();
        var user = await _authRepository.GetUserByJwt(request.Jwt);

        return await Task.FromResult(new AuthResponse());
    }
}
