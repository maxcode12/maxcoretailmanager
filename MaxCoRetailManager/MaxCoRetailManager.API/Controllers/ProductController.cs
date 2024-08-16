using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Features.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaxCoRetailManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IMediator mediator, ILogger<ProductController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(typeof(List<string>), 422)]
    public async Task<IActionResult> Post([FromBody] ProductCreateDto productCreateDto)
    {
        try
        {
            var response = await _mediator.Send(new ProductCommandRequest { ProductCreateDto = productCreateDto });
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating the product");
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(typeof(List<string>), 422)]
    public async Task<IActionResult> Put([FromBody] ProductUpdateDto productUpdateDto)
    {
        try
        {
            var response = await _mediator.Send(new ProductUpdateCommandRequest { ProductUpdateDto = productUpdateDto });
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating the product");
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(typeof(List<string>), 422)]
    public async Task<IActionResult> Delete([FromBody] ProductDeleteDto productDeleteDto)
    {
        try
        {
            await _mediator.Send(new ProductDeleteCommandRequest { ProductDeleteDto = productDeleteDto });
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting the product");
            return BadRequest(ex.Message);
        }
    }
}
