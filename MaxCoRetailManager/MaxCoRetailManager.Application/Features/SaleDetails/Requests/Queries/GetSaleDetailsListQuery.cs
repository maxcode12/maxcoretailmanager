using MaxCoRetailManager.Application.DTOs.SaleDetailDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.SaleDetails.Requests.Queries;

public class GetSaleDetailsListQuery : IRequest<IReadOnlyList<SaleDetailGetDto>>
{
}
