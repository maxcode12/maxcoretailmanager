using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Requests;

public class GetProductByNameRequest : IRequest<ProductGetDto>
{
    public string Name { get; set; } = string.Empty;
}
