using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Requests.Commands;

public class CategoryUpdateCommand : IRequest<Unit>
{
    public CategoryUpdateDto CategoryCreateDto { get; set; } = new();
}
