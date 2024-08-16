using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Commands;

public class ProductUpdateCommandRequest : IRequest<ProductUpdateDto>
{
    public ProductUpdateDto ProductUpdateDto { get; set; }
}
