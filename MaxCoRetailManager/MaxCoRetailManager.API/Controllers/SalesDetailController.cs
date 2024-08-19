using MaxCoRetailManager.Application.DTOs.SaleDetailDTO;
using MaxCoRetailManager.Application.Features.SaleDetails.Requests.Commands;
using MaxCoRetailManager.Application.Features.SaleDetails.Requests.Queries;
using MaxCoRetailManager.Application.Specs;
using MaxCoRetailManager.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaxCoRetailManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesDetailController : ControllerBase
    {
        private IMediator _mediator;
        public SalesDetailController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpGet("GetAllDetailSales")]
        public async Task<ActionResult<IReadOnlyList<SaleDetail>>> GetAllSales(CancellationToken ct)
        {
            var query = new GetSaleDetailsListQuery();
            var result = await _mediator.Send(query, ct);
            return Ok(result);

        }

        [HttpGet("GetDetailSalesById")]
        public async Task<ActionResult<SaleDetail>> GetSaleById(int id, CancellationToken ct)
        {
            var query = new GetSaleDetailsByIdQuery { Id = id };
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }

        [HttpGet("GetDetailSaleByPagination")]
        public async Task<ActionResult<Pagination<SaleDetail>>> GetSalesPagination([FromQuery] GetSalesDetailsPaginationQuery query, CancellationToken ct)
        {
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }

        [HttpPost("CreateSaleDetail")]
        public async Task<ActionResult<SaleDetail>> CreateSale(SaleDetailCreateDto saleDetail, CancellationToken ct)
        {
            var command = new CreateSaleDetailCommand { SaleDetailCreateDto = saleDetail };
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

    }
}
