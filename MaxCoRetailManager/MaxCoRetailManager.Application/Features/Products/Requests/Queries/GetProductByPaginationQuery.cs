using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Specs;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Requests.Queries;

public class GetProductByPaginationQuery : IRequest<Pagination<ProductGetDto>>
{
    public CatalogSpecParams CatalogSpecParams { get; set; } = new();
}
