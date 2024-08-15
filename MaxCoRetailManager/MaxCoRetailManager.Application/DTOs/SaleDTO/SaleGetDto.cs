namespace MaxCoRetailManager.Application.DTOs.SaleDTO;

public class SaleGetDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime SaleDate { get; set; }
    public string SaleBy { get; set; } = string.Empty;


}
