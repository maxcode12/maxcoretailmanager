namespace MaxCoRetailManager.Application.DTOs.SaleDetailDTO;

public class SaleDetailCreateDto
{
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public int Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal Tax { get; set; }
    public DateTime SaleDate { get; set; }
    //public int PaymentId { get; set; }

}
