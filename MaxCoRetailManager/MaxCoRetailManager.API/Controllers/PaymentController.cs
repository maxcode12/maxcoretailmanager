using MaxCoRetailManager.Application.DTOs.PaymentDTO;
using MaxCoRetailManager.Application.Features.Payments.Requests.Commands;
using MaxCoRetailManager.Application.Features.Payments.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaxCoRetailManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]

public class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<PaymentController> _logger;

    public PaymentController(IMediator mediator,
        ILogger<PaymentController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("GetAllPayments")]
    public async Task<ActionResult<IReadOnlyList<PaymentGetDto>>> Get()
    {
        var query = new PaymentsListQuery();
        var payments = await _mediator.Send(query);
        return Ok(payments);
    }

    [HttpPost("CreatePayment")]
    public async Task<ActionResult<PaymentCreateDto>> CreatePayment([FromBody] PaymentCreateDto payment)
    {
        var command = new PaymentCommand() { ModelPayment = payment };
        var newPayment = await _mediator.Send(command);
        return Ok(newPayment);
    }


}
