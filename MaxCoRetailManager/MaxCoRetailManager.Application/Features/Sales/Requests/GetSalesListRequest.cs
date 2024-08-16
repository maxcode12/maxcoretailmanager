using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests;

public class GetSalesListRequest : IRequest<IReadOnlyList<SaleGetDto>>
{
}
