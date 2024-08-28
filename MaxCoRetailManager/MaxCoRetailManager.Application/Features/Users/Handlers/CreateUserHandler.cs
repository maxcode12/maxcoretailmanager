using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Features.Users.Requests.Commands;
using MaxCoRetailManager.Application.Responses;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Users.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, BaseResponse>
{
    private readonly IAuthRepository _authRepository;
    private readonly IMapper _mapper;

    public CreateUserHandler(IAuthRepository authRepository,
        IMapper mapper)
    {
        _authRepository = authRepository;
        _mapper = mapper;
    }
    public async Task<BaseResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse();
        var userExist = await _authRepository.UserExists(request.UserCreateDto.UserName);
        var userEmailExist = await _authRepository.UserExists(request.UserCreateDto.Email);

        if (userExist != null && userEmailExist != null)
        {
            response.Message = "User exist already";
            return response;

        }

        var user = _mapper.Map<User>(request.UserCreateDto);

        await _authRepository.Register(user, request.UserCreateDto.Password);
        response.IsSuccess = true;
        response.Message = "User Created Successfully";

        return response;
    }
}
