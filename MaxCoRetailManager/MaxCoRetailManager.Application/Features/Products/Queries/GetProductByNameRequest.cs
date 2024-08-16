using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Queries;

public class GetProductByNameRequest : IRequest<ProductGetDto>
{
    public string Name { get; set; } = string.Empty;
}
