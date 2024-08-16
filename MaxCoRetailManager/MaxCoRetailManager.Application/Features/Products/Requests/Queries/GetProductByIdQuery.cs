using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Requests.Queries;

public class GetProductByIdQuery : IRequest<ProductGetDto>
{
    public int Id { get; set; }
}
