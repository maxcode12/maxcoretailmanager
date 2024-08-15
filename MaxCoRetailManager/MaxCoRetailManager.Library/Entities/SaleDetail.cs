﻿using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class SaleDetail : Base
{
    public int SaleDetailId { get; set; }
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal Tax { get; set; }
    public DateTime SaleDate { get; set; }
    public Sale Sale { get; set; }
    public Product Product { get; set; }
    public ICollection<Sale> Sales { get; set; }

}
