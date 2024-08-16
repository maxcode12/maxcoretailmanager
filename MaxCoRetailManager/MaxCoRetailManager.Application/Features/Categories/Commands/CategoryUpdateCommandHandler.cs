using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Categories.Commands;

public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommandRequest, CategoryUpdateDto>
{


    Task<CategoryUpdateDto> IRequestHandler<CategoryUpdateCommandRequest, CategoryUpdateDto>.Handle(CategoryUpdateCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
