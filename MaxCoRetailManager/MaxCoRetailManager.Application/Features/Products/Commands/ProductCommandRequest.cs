using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Commands;

public class ProductCommandRequest : IRequest<ProductCreateDto>
{
    public ProductCreateDto ProductCreateDto { get; set; } = new();
}
