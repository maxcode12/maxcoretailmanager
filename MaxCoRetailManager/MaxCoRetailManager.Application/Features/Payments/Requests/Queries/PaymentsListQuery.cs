using MaxCoRetailManager.Application.DTOs.PaymentDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Payments.Requests.Queries;

public class PaymentsListQuery : IRequest<IReadOnlyList<PaymentGetDto>>
{

}
