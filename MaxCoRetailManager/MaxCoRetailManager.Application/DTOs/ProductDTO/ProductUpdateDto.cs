using MaxCoRetailManager.Application.DTOs.Common;
using MaxCoRetailManager.Core.Enums;

namespace MaxCoRetailManager.Application.DTOs.ProductDTO;

public class ProductUpdateDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Category Category { get; set; }

}
