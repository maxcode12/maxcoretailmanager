using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.LocationDTO;
using MaxCoRetailManager.Application.Features.Locations.Requests.Queries;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Locations.Handlers;


public class LocationQueryListHandler : IRequestHandler<LocationQuery, IReadOnlyList<LocationGetDto>>
{
    private readonly IMapper _mapper;
    private readonly ILocationRepository _locationRepository;
    public LocationQueryListHandler(IMapper mapper, ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }
    public async Task<IReadOnlyList<LocationGetDto>> Handle(LocationQuery request, CancellationToken cancellationToken)
    {
        var locationList = await _locationRepository.GetAllAsync();
        var locationListMapper = _mapper.Map<IReadOnlyList<LocationGetDto>>(locationList);

        return locationListMapper;


    }
}
