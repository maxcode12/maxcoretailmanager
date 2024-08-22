using MaxCoRetailManager.Core.Entities;

namespace MaxCoRetailManager.Application.Contracts.Persistence.Products;

public interface IInventoryRepository : IGenericRepository<Inventory>
{
    //Task<Inventory> UpdateAsync(Product product, int quantity);
    //Task DeleteAsync(int id);
    //Task<Inventory> GetByIdAsync(int id);
    //Task<IReadOnlyList<Inventory>> GetAllAsync();
    //Task<IReadOnlyList<Inventory>> GetByProductIdAsync(int productId);
    ////Task<Inventory> AddInventoryAsync(Inventory entity);

    //Task UpdateAsync(Inventory entity);
    //Task UpdateProductInventoryAsync(int locationId, string userId, int quantity);
}
