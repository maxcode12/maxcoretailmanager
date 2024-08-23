using MaxCoRetailManager.Application.DTOs.Common;

namespace MaxCoRetailManager.Application.DTOs.PaymentDTO
{
    public class PaymentGetDto : BaseDto
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
    }
}
