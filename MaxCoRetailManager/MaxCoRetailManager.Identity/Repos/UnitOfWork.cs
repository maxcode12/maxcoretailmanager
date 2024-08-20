using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Identity.IdentityContext;
using Microsoft.EntityFrameworkCore;

namespace MaxCoRetailManager.Identity.Repos;

public class UnitOfWork : IUnitOfWork
{
    private readonly MaxCoRetailIdentityDbContext _context;
    private Dictionary<Type, object> _repos;


    public UnitOfWork(MaxCoRetailIdentityDbContext context)
    {
        _context = context;

    }
    public int Commit()
    {
        return _context.SaveChanges();
    }

    public Task<int> CommitAsync()
    {
        return _context.SaveChangesAsync();
    }


    public IGenericIdentityRepository<T> GetRepositoryIdentity<T>() where T : class
    {
        if (_repos == null)
        {
            _repos = new Dictionary<Type, object>();
        }
        var type = typeof(T);
        if (!_repos.ContainsKey(type))
        {
            _repos[type] = new GenericIdentityRepository<T>(_context);
        }
        return (IGenericIdentityRepository<T>)_repos[type];
    }


    public void Rollback() => _context.Dispose();

    public void Dispose()
    {
        Dispose();
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }


    public Task SaveData<T>(string storedProcedure, T parameters)
    {
        return _context.Database.ExecuteSqlRawAsync(storedProcedure, parameters);
    }
}
