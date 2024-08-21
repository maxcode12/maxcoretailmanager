using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Requests.Commands;

public class ProductCommand : IRequest<ProductCreateDto>
{
    public ProductCreateDto ModelProduct { get; set; } = new();

    public ProductCommand(ProductCreateDto productCreateDto)
    {
        ModelProduct = ModelProduct;
    }
}
