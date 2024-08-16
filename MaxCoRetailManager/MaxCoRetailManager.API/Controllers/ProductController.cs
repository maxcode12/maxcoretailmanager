using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Features.Products.Queries;
using MaxCoRetailManager.Application.Features.Products.Requests;
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

    [HttpGet]
    [ProducesResponseType(typeof(List<ProductGetDto>), 200)]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _mediator.Send(new GetProductRequestById { Id = id });
        return Ok(response);
    }

    [HttpGet("allProducts")]
    [ProducesResponseType(typeof(List<ProductGetDto>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetProductsListRequest());
        return Ok(response);
    }

    [HttpGet("allProductsPagination")]
    [ProducesResponseType(typeof(Pagination<ProductGetDto>), 200)]
    public async Task<IActionResult> GetAllPagination([FromQuery] CatalogSpecParams productSpecParams)
    {
        var response = await _mediator.Send(new GetProductByPaginationRequest { CatalogSpecParams = productSpecParams });
        return Ok(response);
    }
}
