using MaxCoRetailManager.Application.DTOs.SaleDetailDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.SaleDetails.Requests.Queries;

public class GetSaleDetailsByIdQuery : IRequest<SaleDetailGetDto>
{
    public int Id { get; set; }
}
