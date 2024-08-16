using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Persistence.Data;

namespace MaxCoRetailManager.Persistence.Repos;

public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
{
    public InventoryRepository(MaxCoRetailDbContext context) : base(context)
    {
    }
}
