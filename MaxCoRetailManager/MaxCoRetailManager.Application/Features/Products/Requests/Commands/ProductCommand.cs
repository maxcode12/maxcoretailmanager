using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Requests.Commands;

public class ProductCommand : IRequest<ProductCreateDto>
{
    public ProductCreateDto ModelProduct { get; set; }

}
