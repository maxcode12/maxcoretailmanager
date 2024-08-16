using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Requests;

public class GetCategoryByIdRequest : IRequest<CategoryGetDto>
{
    public int Id { get; set; }
}
