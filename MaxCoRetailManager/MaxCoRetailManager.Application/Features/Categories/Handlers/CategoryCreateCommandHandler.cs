using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MaxCoRetailManager.Application.Features.Categories.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Handlers;

public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, CategoryCreateDto>
{
    private readonly Contracts.Persistence.IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthRepository _authenticate;
    public CategoryCreateCommandHandler(Contracts.Persistence.IUnitOfWork unitOfWork, IMapper mapper,
        IAuthRepository authRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authenticate = authRepository;
    }
    public async Task<CategoryCreateDto> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var userId = _authenticate.GetCurrentUserId();
        var categoryRepo = _unitOfWork.GetRepository<Category>();
        if (userId == null)
        {
            throw new Exception("Unauthorized access");
        }

        var category = new Category
        {
            UserId = userId.ToString(),
            Name = request.CategoryCreateDto.Name,
            Description = request.CategoryCreateDto.Description
        };

        await categoryRepo.AddAsync(category);

        return _mapper.Map<CategoryCreateDto>(category);
    }
}
