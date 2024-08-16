using MaxCoRetailManager.Application.DTOs.SaleDetailDTO;
using MaxCoRetailManager.Application.Specs;
using MediatR;

namespace MaxCoRetailManager.Application.Features.SaleDetails.Requests.Queries;

public class GetSalesDetailsPaginationQuery : IRequest<Pagination<SaleDetailGetDto>>
{
    public CatalogSpecParams CatalogSpecParams { get; set; } = new();
}
