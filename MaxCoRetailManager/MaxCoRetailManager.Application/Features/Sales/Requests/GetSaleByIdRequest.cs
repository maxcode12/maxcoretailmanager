using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Requests;

public class GetSaleByIdRequest : IRequest<SaleGetDto>
{
    public int Id { get; set; }
}
