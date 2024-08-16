using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Requests;

public class CategoryUpdateCommandRequest : IRequest<Unit>
{
    public CategoryUpdateDto CategoryCreateDto { get; set; } = new();
}
