using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Categories;
using MaxCoRetailManager.Application.Features.Categories.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Handlers;

public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryUpdateCommandHandler(ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        var getExistingCategory = _categoryRepository.GetAsync(request.CategoryCreateDto.Id);
        var category = _mapper.Map<Category>(request.CategoryCreateDto);
        await _categoryRepository.UpdateAsync(category);
        return Unit.Value;
    }
}
