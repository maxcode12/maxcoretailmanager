using MaxCoRetailManager.Application.DTOs.Common;

namespace MaxCoRetailManager.Application.DTOs.ProductDTO
{
    public class ProductGetDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Sku { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string DeliveryTimeSpan { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public bool IsOnSale { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int LocationId { get; set; }


    }
}
