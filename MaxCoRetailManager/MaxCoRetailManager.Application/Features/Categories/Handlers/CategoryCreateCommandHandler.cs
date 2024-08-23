using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Contracts.Persistence.Categories;
using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MaxCoRetailManager.Application.Features.Categories.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Handlers;

public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, CategoryCreateDto>
{

    private readonly IMapper _mapper;
    private readonly IAuthRepository _authenticate;
    private readonly ICategoryRepository _categoryRepository;
    public CategoryCreateCommandHandler(IMapper mapper,
        ICategoryRepository categoryRepository,
        IAuthRepository authRepository)
    {
        _categoryRepository = categoryRepository;

        _mapper = mapper;
        _authenticate = authRepository;
    }
    public async Task<CategoryCreateDto> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _authenticate.GetCurrentUserId();
        var userId = request.CategoryCreateDto.UserId = currentUser.ToString();

        if (currentUser == null)
        {
            throw new Exception("Unauthorized access");
        }

        var category = new Category
        {
            UserId = userId,
            Name = request.CategoryCreateDto.Name,
            Description = request.CategoryCreateDto.Description
        };
        await _categoryRepository.AddAsync(category);


        return _mapper.Map<CategoryCreateDto>(category);
    }
}
