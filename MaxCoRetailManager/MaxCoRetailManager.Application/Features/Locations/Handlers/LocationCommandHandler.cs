using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.DTOs.LocationDTO;
using MaxCoRetailManager.Application.Features.Locations.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Locations.Handlers;

public class LocationCommandHandler : IRequestHandler<LocationCommand, LocationCreateDto>
{
    private readonly IMapper _mapper;
    private readonly Contracts.Persistence.IUnitOfWork _unitOfWork;
    private readonly IAuthRepository _authRepository;

    public LocationCommandHandler(IMapper mapper,
        Contracts.Persistence.IUnitOfWork unitOfWork,
        IAuthRepository authRepository
        )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _authRepository = authRepository;
    }
    public async Task<LocationCreateDto> Handle(LocationCommand request, CancellationToken cancellationToken)
    {
        var userId = _authRepository.GetCurrentUserId();
        var locationRepo = _unitOfWork.GetRepository<Location>();
        if (userId == null)
        {
            throw new Exception("Unauthorized access");
        }

        var location = new Location
        {

            Name = request.ModelLocation.Name,
            Description = request.ModelLocation.Description
        };
        await locationRepo.AddAsync(location);

        return _mapper.Map<LocationCreateDto>(location);
    }
}
