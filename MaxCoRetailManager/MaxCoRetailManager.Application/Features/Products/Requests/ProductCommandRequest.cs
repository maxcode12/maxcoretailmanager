using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Requests;

public class ProductCommandRequest : IRequest<ProductCreateDto>
{
    public ProductCreateDto ProductCreateDto { get; set; } = new();
}
