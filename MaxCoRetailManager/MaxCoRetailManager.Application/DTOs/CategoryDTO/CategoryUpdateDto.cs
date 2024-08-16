using MaxCoRetailManager.Application.DTOs.Common;

namespace MaxCoRetailManager.Application.DTOs.CategoryDTO;

public class CategoryUpdateDto : BaseDto
{

    public string Name { get; set; }
    public string Description { get; set; }

}
