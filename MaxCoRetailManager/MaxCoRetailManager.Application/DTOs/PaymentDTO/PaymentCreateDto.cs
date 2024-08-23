namespace MaxCoRetailManager.Application.DTOs.PaymentDTO;

public class PaymentCreateDto
{
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public string? PaymentMethod { get; set; }
    public int SaleDetailId { get; set; }
    public int SaleId { get; set; }
    public string CustomerId { get; set; }
    public string UserId { get; set; } = Guid.NewGuid().ToString();

}
