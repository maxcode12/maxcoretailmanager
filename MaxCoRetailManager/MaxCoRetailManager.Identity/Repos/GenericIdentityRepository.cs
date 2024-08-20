using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Identity.IdentityContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MaxCoRetailManager.Identity.Repos;

public class GenericIdentityRepository<T> : IGenericIdentityRepository<T> where T : class
{

    private readonly MaxCoRetailIdentityDbContext _context;
    private DbSet<T> _entities;
    string errorMessage = string.Empty;
    public GenericIdentityRepository(MaxCoRetailIdentityDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }
    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().AnyAsync(expression);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().CountAsync(expression);
    }
    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(expression);
    }

    public virtual async Task<T> GetByIdAsync(object id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> ListAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().Where(expression).ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
