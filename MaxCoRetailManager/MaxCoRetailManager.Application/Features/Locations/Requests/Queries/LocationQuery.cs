using MaxCoRetailManager.Application.DTOs.LocationDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Locations.Requests.Queries;

public class LocationQuery : IRequest<IReadOnlyList<LocationGetDto>>
{
}
