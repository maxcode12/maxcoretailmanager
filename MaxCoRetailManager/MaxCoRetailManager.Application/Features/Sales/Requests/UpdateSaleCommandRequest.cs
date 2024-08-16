using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests;

public class UpdateSaleCommandRequest : IRequest<Unit>
{
    public SaleUpdateDto SaleUpdateDto { get; set; } = new();
}
