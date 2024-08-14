using MaxCoRetailManager.Application.DTOs.Common;
using MaxCoRetailManager.Core.Enums;

namespace MaxCoRetailManager.Application.DTOs.ProductDTO
{
    public class ProductGetDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}
