using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests.Queries;

public class GetSaleByDateQuery : IRequest<SaleGetDto>
{
    public DateTime Date { get; set; }
}
