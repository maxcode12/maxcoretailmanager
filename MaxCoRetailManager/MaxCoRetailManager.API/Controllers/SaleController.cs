using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MaxCoRetailManager.Application.Features.Sales.Requests.Commands;
using MaxCoRetailManager.Application.Features.Sales.Requests.Queries;
using MaxCoRetailManager.Application.Specs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaxCoRetailManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<SaleController> _logger;

    public SaleController(IMediator mediator, ILogger<SaleController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("GetAllSales")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAllSales()
    {
        try
        {
            var response = await _mediator.Send(new GetSalesListQuery());
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching the sales");
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetSaleById")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var response = await _mediator.Send(new GetSaleByIdQuery { Id = id });
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching the sale");
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetSaleByDate")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> SearchByDate(DateTime date)
    {
        try
        {
            var response = await _mediator.Send(new GetSalesByDateQuery { Date = date });
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching the sales");
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetSaleByPagination")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetSalePagination([FromQuery] CatalogSpecParams catalogSpecParams)
    {
        try
        {
            var response = await _mediator.Send(new GetSalesPaginationQuery { CatalogSpecParams = catalogSpecParams });
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching the sales");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("CreateSale")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(typeof(List<string>), 422)]
    public async Task<IActionResult> CreateSale([FromBody] SaleCreateDto saleCreateDto)
    {
        try
        {
            var response = await _mediator.Send(new CreateSaleCommand { SaleCreateDto = saleCreateDto });
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating the sale");
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("UpdateSale")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(typeof(List<string>), 422)]
    public async Task<IActionResult> UpdateSale([FromBody] SaleUpdateDto saleUpdateDto)
    {
        try
        {
            var response = await _mediator.Send(new UpdateSaleCommand { SaleUpdateDto = saleUpdateDto });
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating the sale");
            return BadRequest(ex.Message);
        }
    }
}
