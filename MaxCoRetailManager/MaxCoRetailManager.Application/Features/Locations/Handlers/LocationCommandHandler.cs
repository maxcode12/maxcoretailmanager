using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.LocationDTO;
using MaxCoRetailManager.Application.Features.Locations.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Locations.Handlers;

public class LocationCommandHandler : IRequestHandler<LocationCommand, LocationCreateDto>
{
    private readonly IMapper _mapper;
    private readonly ILocationRepository _locationRepository;
    private readonly IAuthRepository _authRepository;

    public LocationCommandHandler(IMapper mapper,
        ILocationRepository locationRepository,
        IAuthRepository authRepository
        )
    {
        _mapper = mapper;
        _locationRepository = locationRepository;
        _authRepository = authRepository;
    }
    public async Task<LocationCreateDto> Handle(LocationCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _authRepository.GetCurrentUserId();
        var userId = request.ModelLocation.UserId = currentUser.ToString();

        if (userId == null)
        {
            throw new Exception("Unauthorized access");
        }

        var location = new Location
        {
            UserId = userId.ToString(),
            Name = request.ModelLocation.Name,
            Description = request.ModelLocation.Description
        };
        await _locationRepository.AddAsync(location);

        return _mapper.Map<LocationCreateDto>(location);
    }
}
