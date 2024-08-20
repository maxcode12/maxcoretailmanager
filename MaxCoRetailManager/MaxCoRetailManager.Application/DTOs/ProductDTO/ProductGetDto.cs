using MaxCoRetailManager.Application.DTOs.Common;
using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Application.DTOs.ProductDTO
{
    public class ProductGetDto : BaseDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [StringLength(512)] public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get; set; }
        [StringLength(10)] public string DeliveryTimeSpan { get; set; } = string.Empty;
        public int Quantity { get; set; }
        [StringLength(256)] public string ImageUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public bool IsOnSale { get; set; }
        [StringLength(50)] public string CategoryName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        [StringLength(50)] public string UserId { get; set; } = string.Empty;


    }
}
