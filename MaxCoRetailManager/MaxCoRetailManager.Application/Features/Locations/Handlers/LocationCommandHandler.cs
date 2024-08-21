using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence;
using MaxCoRetailManager.Application.DTOs.LocationDTO;
using MaxCoRetailManager.Application.Features.Locations.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Locations.Handlers;

public class LocationCommandHandler : IRequestHandler<LocationCommand, LocationCreateDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public LocationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<LocationCreateDto> Handle(LocationCommand request, CancellationToken cancellationToken)
    {
        var locationRepo = _unitOfWork.GetRepository<Location>();
        var location = _mapper.Map<Location>(request.ModelLocation);
        await locationRepo.AddAsync(location);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<LocationCreateDto>(location);
    }
}
