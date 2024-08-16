using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Requests;

public class GetProductsListRequest : IRequest<IReadOnlyList<ProductGetDto>>
{
}
