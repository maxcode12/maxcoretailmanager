using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Features.Users.Requests.Commands;
using MaxCoRetailManager.Application.Features.Users.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaxCoRetailManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private ISender _send;
    private IAuthRepository _authRepository;

    public AuthController(ISender send,
        IAuthRepository authRepository)
    {
        _send = send;
        _authRepository = authRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
    {
        return Ok(await _send.Send(command));
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] GetUserRequest query)
    {
        return Ok(await _send.Send(query));
    }

    [HttpGet("GetCurrentUser")]
    public async Task<IActionResult> GetCurrentUser()
    {
        return Ok(await _send.Send(new GetCurrentUserRequest()));
    }

    [Authorize]

    [HttpPost("GetUserByJwt")]
    public async Task<IActionResult> GetUserByJwt(string jwt)
    {
        var user = new GetUserByJwtQuery() { Jwt = jwt };
        return Ok(await _send.Send(user));
    }

    [Authorize]

    [HttpGet("GetUserProfile")]
    public async Task<IActionResult> GetUserProfile()
    {
        var user = _authRepository.GetUserProfile();

        return Ok(await _send.Send(user));
    }

}

