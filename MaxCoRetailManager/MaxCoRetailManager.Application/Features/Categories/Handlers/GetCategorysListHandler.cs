﻿using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Categories;
using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MaxCoRetailManager.Application.Features.Categories.Requests.Queries;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Handlers;

public class GetCategorysListHandler : IRequestHandler<GetCategorysListQuery, IReadOnlyList<CategoryGetDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategorysListHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<IReadOnlyList<CategoryGetDto>> Handle(GetCategorysListQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAllAsync();
        var categoryMapper = _mapper.Map<IReadOnlyList<CategoryGetDto>>(category);

        return categoryMapper;
    }
}
