using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Requests.Queries;

public class GetProductsListQuery : IRequest<IReadOnlyList<ProductGetDto>>
{
}
