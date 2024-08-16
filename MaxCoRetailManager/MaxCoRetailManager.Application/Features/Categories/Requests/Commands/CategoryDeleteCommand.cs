using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Requests.Commands;

public class CategoryDeleteCommand : IRequest<Unit>
{
    public CategoryDeleteDto CategoryDeleteDto { get; set; } = new();
}
