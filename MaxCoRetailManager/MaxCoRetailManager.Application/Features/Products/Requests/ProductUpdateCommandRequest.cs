using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Requests;

public class ProductUpdateCommandRequest : IRequest<ProductUpdateDto>
{
    public ProductUpdateDto ProductUpdateDto { get; set; } = new();
}
