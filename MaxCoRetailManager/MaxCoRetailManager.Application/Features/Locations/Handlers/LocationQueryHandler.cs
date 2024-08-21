
using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence;
using MaxCoRetailManager.Application.DTOs.LocationDTO;
using MaxCoRetailManager.Application.Features.Locations.Requests.Queries;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Locations.Handlers;

public class LocationQueryHandler : IRequestHandler<LocationQuery, IReadOnlyList<LocationGetDto>>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public LocationQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public async Task<IReadOnlyList<LocationGetDto>> Handle(LocationQuery request, CancellationToken cancellationToken)
    {
        var locationRepo = unitOfWork.GetRepository<Location>();
        var locations = await locationRepo.GetAllAsync();
        return mapper.Map<IReadOnlyList<LocationGetDto>>(locations);

    }
}
