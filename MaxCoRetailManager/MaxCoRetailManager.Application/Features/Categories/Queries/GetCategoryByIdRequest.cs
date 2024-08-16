using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Queries;

public class GetCategoryByIdRequest : IRequest<CategoryGetDto>
{
    public int Id { get; set; }
}
