using System.Linq.Expressions;

namespace MaxCoRetailManager.Application.Contracts.Identity;

public interface IGenericIdentityRepository<T> where T : class
{
    Task<T> GetByIdAsync(object id);
    Task<List<T>> ListAllAsync();
    Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    void Remove(T entity);
    Task<int> CountAsync(Expression<Func<T, bool>> expression);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
}
