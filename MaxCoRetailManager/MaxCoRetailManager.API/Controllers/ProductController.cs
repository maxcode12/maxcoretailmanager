using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Features.Products.Requests.Commands;
using MaxCoRetailManager.Application.Features.Products.Requests.Queries;
using MaxCoRetailManager.Application.Specs;
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

    [HttpPost("CreateProduct")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(typeof(List<string>), 422)]
    public async Task<IActionResult> Post([FromBody] ProductCreateDto productCreateDto)
    {
        try
        {
            var response = await _mediator.Send(new ProductCommand { ProductCreateDto = productCreateDto });
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating the product");
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("UpdateProduct")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(typeof(List<string>), 422)]
    public async Task<IActionResult> Put([FromBody] ProductUpdateDto productUpdateDto)
    {
        try
        {
            var response = await _mediator.Send(new ProductUpdateCommand { ProductUpdateDto = productUpdateDto });
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating the product");
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("DeleteProduct")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(typeof(List<string>), 422)]
    public async Task<IActionResult> Delete([FromBody] ProductDeleteDto productDeleteDto)
    {
        try
        {
            await _mediator.Send(new ProductDeleteCommand { ProductDeleteDto = productDeleteDto });
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting the product");
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetProductById")]
    [ProducesResponseType(typeof(List<ProductGetDto>), 200)]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _mediator.Send(new GetProductByIdQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("GetAllProducts")]
    [ProducesResponseType(typeof(List<ProductGetDto>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetProductsListQuery());
        return Ok(response);
    }

    [HttpGet("GetProductByPagination")]
    [ProducesResponseType(typeof(Pagination<ProductGetDto>), 200)]
    public async Task<IActionResult> GetAllPagination([FromQuery] CatalogSpecParams productSpecParams)
    {
        var response = await _mediator.Send(new GetProductByPaginationQuery { CatalogSpecParams = productSpecParams });
        return Ok(response);
    }
}
