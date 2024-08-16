using MaxCoRetailManager.Application.Contracts.Persistence.Categories;
using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Persistence.Data;

namespace MaxCoRetailManager.Persistence.Repos;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(MaxCoRetailDbContext context) : base(context)
    {
    }
}
