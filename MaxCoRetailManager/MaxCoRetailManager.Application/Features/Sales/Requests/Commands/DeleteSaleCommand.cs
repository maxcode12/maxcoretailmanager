using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests.Commands;

public class DeleteSaleCommand : IRequest<Unit>
{
    public SaleDeleteDto SaleDeleteDto { get; set; } = new();
}
