using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Requests.Queries;

public class GetProductByNameQuery : IRequest<ProductGetDto>
{
    public string Name { get; set; } = string.Empty;
}
