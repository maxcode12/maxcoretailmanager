using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Queries;

public class GetProductRequestById : IRequest<ProductGetDto>
{
    public int Id { get; set; }
}
