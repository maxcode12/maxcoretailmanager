using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Specs;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Queries;

public class GetProductByPaginationRequest : IRequest<Pagination<ProductGetDto>>
{
    public CatalogSpecParams CatalogSpecParams { get; set; } = new();
}
