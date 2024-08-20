﻿using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Features.Users.Requests.Commands;
using MaxCoRetailManager.Application.Features.Users.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaxCoRetailManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private ISender _send;

    public AuthController(ISender send,
        IAuthRepository authRepository)
    {
        _send = send;

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

}
