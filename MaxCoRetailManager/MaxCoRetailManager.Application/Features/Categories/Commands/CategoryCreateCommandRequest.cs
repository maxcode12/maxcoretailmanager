using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Commands;

public class CategoryCreateCommandRequest : IRequest<CategoryCreateDto>
{
    public CategoryCreateDto CategoryCreateDto { get; set; } = new();
}
