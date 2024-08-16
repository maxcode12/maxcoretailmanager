using FluentValidation;
using MaxCoRetailManager.Application.Contracts.Persistence.Categories;
using MaxCoRetailManager.Application.DTOs.CategoryDTO;

namespace MaxCoRetailManager.Application.Validators.Category;

public class CategoryDeleteValidator : AbstractValidator<CategoryDeleteDto>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryDeleteValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Id is required.")
            .NotNull();
    }
}
