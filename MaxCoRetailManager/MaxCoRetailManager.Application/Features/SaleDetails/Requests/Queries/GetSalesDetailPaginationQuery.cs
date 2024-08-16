using MaxCoRetailManager.Application.DTOs.SaleDetailDTO;
using MaxCoRetailManager.Application.Specs;
using MediatR;

namespace MaxCoRetailManager.Application.Features.SaleDetails.Requests.Queries;

public class GetSalesDetailPaginationQuery : IRequest<Pagination<SaleDetailGetDto>>
{
    public CatalogSpecParams CatalogSpecParams { get; set; } = new();
}
