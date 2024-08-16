using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests;

public class DeleteSaleCommandRequest : IRequest<Unit>
{
    public SaleDeleteDto SaleDeleteDto { get; set; } = new();
}
