using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Commands;

public class ProductDeleteCommandRequest : IRequest<Unit>
{
    public ProductDeleteDto ProductDeleteDto { get; set; }
}
