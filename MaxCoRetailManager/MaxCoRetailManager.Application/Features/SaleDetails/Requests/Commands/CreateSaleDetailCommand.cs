using MaxCoRetailManager.Application.DTOs.SaleDetailDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.SaleDetails.Requests.Commands;

public class CreateSaleDetailCommand : IRequest<SaleDetailCreateDto>
{
    public SaleDetailCreateDto SaleDetailCreateDto { get; set; } = new();
}
