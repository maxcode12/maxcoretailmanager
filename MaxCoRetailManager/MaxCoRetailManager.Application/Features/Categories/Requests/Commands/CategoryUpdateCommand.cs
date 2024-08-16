using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Requests.Commands;

public class CategoryUpdateCommand : IRequest<CategoryUpdateDto>
{
    public CategoryUpdateDto CategoryUpdateDto { get; set; } = new();
}
