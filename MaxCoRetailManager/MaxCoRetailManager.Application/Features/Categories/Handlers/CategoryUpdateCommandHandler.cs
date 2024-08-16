using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Categories;
using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MaxCoRetailManager.Application.Features.Categories.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Handlers;

public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, CategoryUpdateDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryUpdateCommandHandler(ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryUpdateDto> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {

        var category = _mapper.Map<Category>(request.CategoryUpdateDto);
        await _categoryRepository.UpdateAsync(category);
        return _mapper.Map<CategoryUpdateDto>(category);
    }
}
