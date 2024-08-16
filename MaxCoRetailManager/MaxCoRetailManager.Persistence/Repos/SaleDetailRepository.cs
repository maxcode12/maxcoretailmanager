using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Persistence.Data;

namespace MaxCoRetailManager.Persistence.Repos;

public class SaleDetailRepository : GenericRepository<SaleDetail>, ISaleDetailRepository
{
    public SaleDetailRepository(MaxCoRetailDbContext context) : base(context)
    {
    }
}
