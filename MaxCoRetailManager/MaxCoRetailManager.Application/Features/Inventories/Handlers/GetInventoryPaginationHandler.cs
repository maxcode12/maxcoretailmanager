using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.Features.Inventories.Requests.Queries;
using MaxCoRetailManager.Application.Specs;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Handlers;

public class GetInventoryPaginationHandler : IRequestHandler<GetInventoryPaginationQuery, Pagination<InventoryGetDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetInventoryPaginationHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Pagination<InventoryGetDto>> Handle(GetInventoryPaginationQuery request, CancellationToken cancellationToken)
    {
        var spec = await _unitOfWork.GetRepository<Inventory>().GetAllPagination(request.CatalogSpecParams);
        var specMapper = _mapper.Map<Pagination<InventoryGetDto>>(spec); // Mapping the spec to the DTO

        return specMapper;

    }
}
