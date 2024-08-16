using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Requests;

public class CategoryDeleteCommandRequest : IRequest<Unit>
{
    public CategoryDeleteDto CategoryDeleteDto { get; set; } = new();
}
