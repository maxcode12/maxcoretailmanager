using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Requests.Commands;

public class ProductDeleteCommand : IRequest<Unit>
{
    public ProductDeleteDto ProductDeleteDto { get; set; } = new();
}
