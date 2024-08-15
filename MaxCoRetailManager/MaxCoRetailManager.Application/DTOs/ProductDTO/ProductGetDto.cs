using MaxCoRetailManager.Application.DTOs.Common;

namespace MaxCoRetailManager.Application.DTOs.ProductDTO
{
    public class ProductGetDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Categoryid { get; set; }
    }
}
