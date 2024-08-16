﻿using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Queries;

public class GetCategorysListRequest : IRequest<IReadOnlyList<CategoryGetDto>>
{
    public CategoryGetDto Category { get; set; } = new();
}
