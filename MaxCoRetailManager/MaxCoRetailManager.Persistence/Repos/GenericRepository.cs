using MaxCoRetailManager.Application.Contracts.Persistence;
using MaxCoRetailManager.Application.Specs;
using MaxCoRetailManager.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace MaxCoRetailManager.Persistence.Repos;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly MaxCoRetailDbContext _context;

    public GenericRepository(MaxCoRetailDbContext context)
    {
        _context = context;

    }
    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        await Task.Run(() =>
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        });
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetAsync(int id) => await _context.Set<T>().FindAsync(id);
    public async Task<T> GetAsync(string id) => await _context.Set<T>().FindAsync(id);

    public async Task<IReadOnlyList<T>> GetAllPaginationAsync(int pageIndex, int pageSize,
        int count, IReadOnlyList<T> entity)
    {
        return await _context.Set<T>().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<bool> IsExist(int id)
    {
        var item = await _context.Set<T>().FindAsync(id);
        return item != null;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Pagination<T>> GetAllPagination(CatalogSpecParams catalogSpecParams)
    {
        var query = _context.Set<T>().AsQueryable();
        var count = query.Count();
        var data = await query.Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1)).ToListAsync();
        return new Pagination<T>(catalogSpecParams.PageIndex, catalogSpecParams.PageSize, count, data);

    }
}
