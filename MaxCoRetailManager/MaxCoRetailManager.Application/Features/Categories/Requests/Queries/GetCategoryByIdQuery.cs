using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Requests.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryGetDto>
{
    public int Id { get; set; }
}
