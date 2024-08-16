using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests.Commands;

public class UpdateSaleCommand : IRequest<Unit>
{
    public SaleUpdateDto SaleUpdateDto { get; set; } = new();
}
