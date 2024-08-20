namespace MaxCoRetailManager.Application.DTOs.CategoryDTO;

public class CategoryCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ParentCategoryId { get; set; }
    public string UserId { get; set; } = string.Empty;


}
