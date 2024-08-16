using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Categories;
using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MaxCoRetailManager.Application.Features.Categories.Requests;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Commands;

public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommandRequest, CategoryCreateDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryCreateCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<CategoryCreateDto> Handle(CategoryCreateCommandRequest request, CancellationToken cancellationToken)
    {
        //var validator = new CategoryCreateValidator();
        //var validationResult = validator.Validate(request.CategoryCreateDto);

        //if (validationResult != null)
        //{
        //    throw new ValidationException(validationResult.ToString());
        //}

        var category = _mapper.Map<Category>(request.CategoryCreateDto);
        await _categoryRepository.AddAsync(category);
        return _mapper.Map<CategoryCreateDto>(category);
    }
}
