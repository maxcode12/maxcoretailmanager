using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MaxCoRetailManager.Application.Specs;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests;

public class GetSalePaginationRequest : IRequest<Pagination<SaleGetDto>>
{
    public CatalogSpecParams CatalogSpecParams { get; set; } = new();
}
