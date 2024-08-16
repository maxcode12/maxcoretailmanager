using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests.Queries;

public class GetSalesByDateQuery : IRequest<SaleGetDto>
{
    public DateTime Date { get; set; }
}
