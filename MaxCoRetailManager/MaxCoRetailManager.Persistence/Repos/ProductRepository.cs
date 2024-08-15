using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Persistence.Data;

namespace MaxCoRetailManager.Persistence.Repos;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(MaxCoRetailDbContext context) : base(context)
    {
    }
}
