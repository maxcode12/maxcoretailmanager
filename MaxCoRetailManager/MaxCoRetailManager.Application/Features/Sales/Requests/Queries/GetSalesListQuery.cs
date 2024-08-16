using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests.Queries;

public class GetSalesListQuery : IRequest<IReadOnlyList<SaleGetDto>>
{
}
