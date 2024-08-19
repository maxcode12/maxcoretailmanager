using MaxCoRetailManager.Application.Features.Inventories.Requests.Commands;
using MaxCoRetailManager.Application.Features.Inventories.Requests.Queries;
using MaxCoRetailManager.Application.Specs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaxCoRetailManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<InventoryController> _logger;

    public InventoryController(IMediator mediator, ILogger<InventoryController> logger)
    {
        _mediator = mediator;
        _logger = logger;

    }

    [HttpGet("GetAllInventory")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAllInventory()
    {
        try
        {
            var response = await _mediator.Send(new GetInventoryListQuery());
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching the inventory");
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetInventoryById")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetInventoryById(int id)
    {
        try
        {
            var response = await _mediator.Send(new GetInventoryByIdQuery { Id = id });
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching the inventory");
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetInventoryByPagination")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetInventoryByPagination([FromQuery] CatalogSpecParams query)
    {
        try
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching the inventory");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("CreateInventory")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating the inventory");
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("UpdateInventory")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateInventory([FromBody] UpdateInventoryCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating the inventory");
            return BadRequest(ex.Message);
        }
    }
}
