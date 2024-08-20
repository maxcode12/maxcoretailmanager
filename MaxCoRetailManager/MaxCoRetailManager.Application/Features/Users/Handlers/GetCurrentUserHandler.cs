using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Features.Users.Requests.Queries;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Handlers;

public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserRequest, Guid?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthRepository _authRepository;
    public GetCurrentUserHandler(IUnitOfWork unitOfWork,
        IAuthRepository authRepository)
    {
        _unitOfWork = unitOfWork;
        _authRepository = authRepository;
    }
    public async Task<Guid?> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken)
    {
        var userId = _authRepository.GetCurrentUserId();


        return await Task.FromResult(userId);
    }
}
