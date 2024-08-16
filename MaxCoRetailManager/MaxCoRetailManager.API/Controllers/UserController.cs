using MaxCoRetailManager.Application.DTOs.UserDTO;
using MaxCoRetailManager.Application.Features.Users.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaxCoRetailManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _send;

        public UserController(IMediator send)
        {
            _send = send;
        }

        [HttpGet("UserList")]
        [ProducesResponseType(typeof(IReadOnlyList<UserGetDto>), 200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Get()
        {
            var users = await _send.Send(new GetUserRequestList());
            return Ok(users);
        }
    }
}
