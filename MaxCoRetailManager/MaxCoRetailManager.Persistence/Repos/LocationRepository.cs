using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace MaxCoRetailManager.Persistence.Repos;

public class LocationRepository : ILocationRepository
{
    private readonly MaxCoRetailDbContext _context;

    public LocationRepository(MaxCoRetailDbContext context)
    {
        _context = context;
    }

    public async Task AddLocationAsync(Location entity)
    {
        await _context.Locations.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLocationAysnc(int id)
    {
        await _context.Locations.FindAsync(id);
        _context.Locations.Remove(await _context.Locations.FindAsync(id));
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Location>> GetAllLocationAsync()
    {
        return await _context.Locations.ToListAsync();
    }

    public async Task<IReadOnlyList<Location>> GetLocationByUserIdAysnc(string userId)
    {
        return await _context.Locations.Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<Location> GetLocationIdAsync(int locationId)
    {
        return await _context.Locations.FindAsync(locationId);
    }

    public async Task<Location> GetLocationIdAsync(string locationName)
    {
        return await _context.Locations.FirstOrDefaultAsync(c => c.Name == locationName);
    }

    public async Task UpdateLocationAsync(Location entity)
    {
        _context.Entry(entity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }
}
