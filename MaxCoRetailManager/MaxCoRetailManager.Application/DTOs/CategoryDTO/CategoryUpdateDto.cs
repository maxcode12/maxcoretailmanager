using MaxCoRetailManager.Application.DTOs.Common;

namespace MaxCoRetailManager.Application.DTOs.CategoryDTO;

public class CategoryUpdateDto : BaseDto
{

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ParentCategoryId { get; set; }

    public string UserId { get; set; } = Guid.NewGuid().ToString();
}
