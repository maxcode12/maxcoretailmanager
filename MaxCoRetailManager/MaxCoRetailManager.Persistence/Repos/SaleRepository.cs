using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Persistence.Data;

namespace MaxCoRetailManager.Persistence.Repos;

public class SaleRepository : GenericRepository<Sale>, ISaleRepository
{
    public SaleRepository(MaxCoRetailDbContext context) : base(context)
    {
    }
}
