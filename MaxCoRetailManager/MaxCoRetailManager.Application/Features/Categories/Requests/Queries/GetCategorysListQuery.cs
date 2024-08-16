using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Requests.Queries;

public class GetCategorysListQuery : IRequest<IReadOnlyList<CategoryGetDto>>
{
    public CategoryGetDto Category { get; set; } = new();
}
