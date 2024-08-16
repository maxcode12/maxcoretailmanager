using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests;

public class CreateSaleCommandRequest : IRequest<SaleCreateDto>
{
    public SaleCreateDto SaleCreateDto { get; set; } = new();


}
