using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.Features.Inventories.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Handlers;

public class CreateInventoryHandler : IRequestHandler<CreateInventoryCommand, InventoryCreateDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateInventoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<InventoryCreateDto> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
    {
        var inventory = _mapper.Map<Inventory>(request.Inventory);
        await _unitOfWork.GetRepository<Inventory>().AddAsync(inventory);
        return _mapper.Map<InventoryCreateDto>(inventory);
    }
}
