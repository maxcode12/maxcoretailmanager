﻿using FluentValidation;
using MaxCoRetailManager.Application.Contracts.Persistence.Categories;
using MaxCoRetailManager.Application.DTOs.CategoryDTO;

namespace MaxCoRetailManager.Application.Validators.Category;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    private readonly ICategoryRepository _categoryReposity;
    public CategoryCreateValidator(ICategoryRepository categoryRepository)
    {
        _categoryReposity = categoryRepository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Name is required.")
            .NotNull()
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");


    }
}
