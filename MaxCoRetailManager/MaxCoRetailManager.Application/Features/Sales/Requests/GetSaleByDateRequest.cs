using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests;

public class GetSaleByDateRequest : IRequest<SaleGetDto>
{
    public DateTime Date { get; set; }
}
