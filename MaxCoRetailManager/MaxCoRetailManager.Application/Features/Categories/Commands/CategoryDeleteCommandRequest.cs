using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Commands;

public class CategoryDeleteCommandRequest : IRequest<CategoryDeleteDto>
{
}
