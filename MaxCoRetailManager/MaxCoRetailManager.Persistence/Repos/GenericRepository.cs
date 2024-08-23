using MaxCoRetailManager.Application.Contracts.Persistence;
using MaxCoRetailManager.Application.Specs;
using MaxCoRetailManager.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace MaxCoRetailManager.Persistence.Repos;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly MaxCoRetailDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(MaxCoRetailDbContext context)
    {
        _context = context;

        _dbSet = _context.Set<T>();
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

    //public async Task UpdateAsync(T entity, object id)
    //{
    //    var existing = await _context.Set<T>().FindAsync(id);
    //    if (existing != null)
    //    {
    //        _context.Entry(existing).CurrentValues.SetValues(entity);
    //        await _context.SaveChangesAsync();
    //    }
    //}
    public async Task<Pagination<T>> GetAllPagination(CatalogSpecParams catalogSpecParams)
    {
        var query = _context.Set<T>().AsQueryable();
        var count = query.Count();
        var data = await query.Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1)).ToListAsync();
        return new Pagination<T>(catalogSpecParams.PageIndex, catalogSpecParams.PageSize, count, data);

    }

    public async Task<T> GetAsync(DateTime date)
    {
        return await _context.Set<T>().FindAsync(date);
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        try
        {
            IQueryable<T> query = ConstructQuery(orderBy, include);
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<T> GetSingleByAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool tracking = false)
    {
        try
        {
            IQueryable<T> query = ConstructQuery(predicate, orderBy, skip, take, include);
            if (!tracking)
                return await query.AsNoTracking().FirstOrDefaultAsync();
            return await query.FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<T> GetSingleByAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
    }


    private IQueryable<T> ConstructQuery(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
    {
        IQueryable<T> query = _dbSet;

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (include != null)
            query = include(query);

        return query;
    }


    private IQueryable<T> ConstructQuery(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int? skip, int? take, params string[] includeProperties)
    {
        IQueryable<T> query = _dbSet;

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        for (int i = 0; i < includeProperties.Length; i++)
        {
            query = query.Include(includeProperties[i]);
        }

        if (skip != null)
        {
            query = query.Skip(skip.Value);
        }

        if (take != null)
        {
            query = query.Take(take.Value);
        }

        return query;
    }

    private IQueryable<T> ConstructQuery(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int? skip, int? take, Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
    {
        IQueryable<T> query = _dbSet;

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (include != null) query = include(query);

        if (skip != null)
        {
            query = query.Skip(skip.Value);
        }

        if (take != null)
        {
            query = query.Take(take.Value);
        }

        return query;
    }

    private IQueryable<T> ConstructQueryable(Expression<Func<T, bool>> predicate = null, string orderBy = null, int? skip = null, int? take = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        try
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
                query = _dbSet.Where(predicate);

            if (include != null)
                query = include(query);

            if (take != null && skip != null)
                return query.Skip(skip.Value).Take(take.Value);
            return query;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


}


