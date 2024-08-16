using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Requests.Commands;

public class ProductUpdateCommand : IRequest<ProductUpdateDto>
{
    public ProductUpdateDto ProductUpdateDto { get; set; } = new();
}
