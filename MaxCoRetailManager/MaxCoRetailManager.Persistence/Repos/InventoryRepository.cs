using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Persistence.Data;

namespace MaxCoRetailManager.Persistence.Repos;

public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
{
    public InventoryRepository(MaxCoRetailDbContext context) : base(context)
    {
    }
    //private readonly MaxCoRetailDbContext _context;

    //public InventoryRepository(MaxCoRetailDbContext context)
    //{
    //    _context = context;
    //}

    //public async Task DeleteAsync(int id)
    //{
    //    _context.Set<Inventory>().Remove(await GetByIdAsync(id));
    //    await _context.SaveChangesAsync();
    //}

    //public async Task<IReadOnlyList<Inventory>> GetAllAsync()
    //{
    //    return await _context.Set<Inventory>().ToListAsync();

    //}

    //public async Task<Inventory> GetByIdAsync(int id)
    //{
    //    return await _context.Set<Inventory>().FindAsync(id);
    //}

    //public async Task<IReadOnlyList<Inventory>> GetByProductIdAsync(int productId)
    //{
    //    return await _context.Set<Inventory>().Where(x => x.ProductId == productId).ToListAsync();
    //}

    //public async Task<Inventory> UpdateAsync(Product product, int quantity)
    //{
    //    var inventory = new Inventory
    //    {
    //        ProductId = product.Id,
    //        Quantity = quantity
    //    };
    //    await _context.Set<Inventory>().AddAsync(inventory);
    //    await _context.SaveChangesAsync();
    //    return inventory;

    //}

    //public async Task UpdateAsync(Inventory entity)
    //{
    //    _context.Entry(entity).State = EntityState.Modified;

    //    await _context.SaveChangesAsync();

    //}

    //public async Task UpdateProductInventoryAsync(int locationId, string userId, int quantity)
    //{
    //    await _context.Set<Inventory>().AddAsync(new Inventory
    //    {
    //        LocationId = locationId,
    //        UserId = userId,
    //        Quantity = quantity
    //    });
    //    await _context.SaveChangesAsync();
    //}

    //{
    //    private readonly MaxCoRetailDbContext _context;
    //    public InventoryRepository(MaxCoRetailDbContext context)
    //    {
    //        _context = context;
    //    }


    //    public async Task DeleteAsync(int id)
    //    {
    //        _context.Set<Inventory>().Remove(await GetByIdAsync(id));
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task<IReadOnlyList<Inventory>> GetAllAsync()
    //    {
    //        return await _context.Set<Inventory>().ToListAsync();

    //    }

    //    public async Task<Inventory> GetByIdAsync(int id)
    //    {
    //        return await _context.Set<Inventory>().FindAsync(id);
    //    }

    //    public async Task<IReadOnlyList<Inventory>> GetByProductIdAsync(int productId)
    //    {
    //        return await _context.Set<Inventory>().Where(x => x.ProductId == productId).ToListAsync();
    //    }

    //    public async Task<Inventory> UpdateAsync(Product product, int quantity)
    //    {
    //        var inventory = new Inventory
    //        {
    //            ProductId = product.Id,
    //            Quantity = quantity
    //        };
    //        await _context.Set<Inventory>().AddAsync(inventory);
    //        await _context.SaveChangesAsync();
    //        return inventory;

    //    }

    //    public async Task UpdateAsync(Inventory entity)
    //    {
    //        _context.Entry(entity).State = EntityState.Modified;

    //        await _context.SaveChangesAsync();

    //    }

    //    public async Task UpdateProductInventoryAsync(int locationId, string userId, int quantity)
    //    {
    //        await _context.Set<Inventory>().AddAsync(new Inventory
    //        {
    //            LocationId = locationId,
    //            UserId = userId,
    //            Quantity = quantity
    //        });
    //        await _context.SaveChangesAsync();
    //    }


}
