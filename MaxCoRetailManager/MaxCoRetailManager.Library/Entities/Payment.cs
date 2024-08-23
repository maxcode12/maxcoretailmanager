using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class Payment : Base
{

    public decimal? Amount { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public string? PaymentMethod { get; set; }


    public virtual int SaleDetailId { get; set; }
    public int? SaleId { get; set; }
    public string? CustomerId { get; set; }
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public virtual Customer? Customer { get; set; }
    public virtual Sale? Sale { get; set; }
    public virtual SaleDetail? SaleDetail { get; set; }

}
