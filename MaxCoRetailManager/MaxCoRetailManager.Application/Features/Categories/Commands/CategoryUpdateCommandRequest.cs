using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Commands;

public class CategoryUpdateCommandRequest : IRequest<CategoryUpdateDto>
{
    public CategoryUpdateDto CategoryCreateDto { get; set; }
}
