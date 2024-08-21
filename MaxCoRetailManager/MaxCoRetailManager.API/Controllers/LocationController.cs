using MaxCoRetailManager.Application.DTOs.LocationDTO;
using MaxCoRetailManager.Application.Features.Locations.Requests.Commands;
using MaxCoRetailManager.Application.Features.Locations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaxCoRetailManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("GetAllLocation")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAllLocation()
    {
        try
        {
            var response = await _mediator.Send(new LocationQuery());
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("CreateLocation")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateLocation([FromBody] LocationCreateDto location)
    {
        try
        {
            var response = await _mediator.Send(new LocationCommand { ModelLocation = location });
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
