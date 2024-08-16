using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Queries;

public class GetProductsListRequest : IRequest<IReadOnlyList<ProductGetDto>>
{
}
