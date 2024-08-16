using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Categories;
using MaxCoRetailManager.Application.Features.Categories.Requests;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Commands;

public class CategoryDeletCommandHandler : IRequestHandler<CategoryDeleteCommandRequest, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryDeletCommandHandler(ICategoryRepository category, IMapper mapper)
    {
        _categoryRepository = category;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CategoryDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var categoryMapped = _mapper.Map<Category>(request.CategoryDeleteDto);
        await _categoryRepository.DeleteAsync(categoryMapped);
        return Unit.Value;
    }
}
