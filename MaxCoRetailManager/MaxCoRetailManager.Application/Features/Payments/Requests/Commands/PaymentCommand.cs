using MaxCoRetailManager.Application.DTOs.PaymentDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Payments.Requests.Commands;

public class PaymentCommand : IRequest<PaymentCreateDto>
{
    public PaymentCreateDto ModelPayment { get; set; }


}
