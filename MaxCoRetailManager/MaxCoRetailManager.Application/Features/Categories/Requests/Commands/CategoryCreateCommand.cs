using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Requests.Commands;

public class CategoryCreateCommand : IRequest<CategoryCreateDto>
{
    public CategoryCreateDto CategoryCreateDto { get; set; }

}
