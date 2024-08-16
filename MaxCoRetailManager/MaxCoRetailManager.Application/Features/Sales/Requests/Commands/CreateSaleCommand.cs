using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests.Commands;

public class CreateSaleCommand : IRequest<SaleCreateDto>
{
    public SaleCreateDto SaleCreateDto { get; set; } = new();


}
