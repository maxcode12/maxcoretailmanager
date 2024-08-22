using MaxCoRetailManager.Application.DTOs.LocationDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Locations.Requests.Commands;

public class LocationCommand : IRequest<LocationCreateDto>
{
    public LocationCreateDto ModelLocation { get; set; } = new();

}
