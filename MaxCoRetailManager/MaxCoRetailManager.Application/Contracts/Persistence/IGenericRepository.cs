using MaxCoRetailManager.Application.Specs;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace MaxCoRetailManager.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetAsync(object id);
    Task<T> GetAsync(string id);
    Task<T> GetAsync(DateTime date);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllPaginationAsync(int pageIndex, int pageSize,
        int count, IReadOnlyList<T> entity);

    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    //Task UpdateAsync(T entity, object id);
    Task DeleteAsync(T entity);
    Task<bool> IsExist(int id);
    Task<Pagination<T>> GetAllPagination(CatalogSpecParams catalogSpecParams);
    Task<T> GetSingleByAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool tracking = false);
    Task<T> GetSingleByAsync(Expression<Func<T, bool>> predicate);
}

