using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Persistence.Data;

namespace MaxCoRetailManager.Persistence.Repos;

public class LocationRepository : GenericRepository<Location>, ILocationRepository
{
    public LocationRepository(MaxCoRetailDbContext context) : base(context)
    {
    }


}
