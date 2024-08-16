using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests.Queries;

public class GetSaleByIdQuery : IRequest<SaleGetDto>
{
    public int Id { get; set; }
}
