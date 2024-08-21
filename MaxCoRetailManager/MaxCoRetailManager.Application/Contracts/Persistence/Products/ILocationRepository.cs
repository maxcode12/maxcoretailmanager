using MaxCoRetailManager.Core.Entities;

namespace MaxCoRetailManager.Application.Contracts.Persistence.Products;

public interface ILocationRepository
{
    Task<Location> GetLocationIdAsync(int locationId);
    Task<Location> GetLocationIdAsync(string locationName);
    Task<IReadOnlyList<Location>> GetLocationByUserIdAysnc(string userId);
    Task AddLocationAsync(Location entity);
    Task UpdateLocationAsync(Location entity);
    Task DeleteLocationAysnc(int id);
    //Task<bool> IsLocationAvailable(int locationId);
    //Task<bool> IsLocationAvailable(int locationId, string locationName);
    //Task<bool> IsLocationAvailable(int locationId, string locationName, string userId);
    //Task<bool> IsLocationAvailable(string locationName, string userId);
    Task<IReadOnlyList<Location>> GetAllLocationAsync();


}
