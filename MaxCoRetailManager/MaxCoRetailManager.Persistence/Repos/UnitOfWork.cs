using MaxCoRetailManager.Application.Contracts.Persistence;
using MaxCoRetailManager.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace MaxCoRetailManager.Persistence.Repos;

public class UnitOfWork : IUnitOfWork
{
    private readonly MaxCoRetailDbContext _context;
    private Dictionary<Type, object> _repos;
    //private ConnectionString _connectionString;
    public UnitOfWork(MaxCoRetailDbContext context)
    {
        _context = context;
        //_connectionString = connectionString;
    }

    public int Commit()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    public void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }

    public Task<int> CommitAsync()
    {
        return _context.SaveChangesAsync();
    }

    public IGenericRepository<T> GetRepository<T>() where T : class
    {
        if (_repos == null)
        {
            _repos = new Dictionary<Type, object>();
        }
        var type = typeof(T);
        if (!_repos.ContainsKey(type))
        {
            _repos[type] = new GenericRepository<T>(_context);
        }
        return (IGenericRepository<T>)_repos[type];
    }

    public void Rollback()
    {
        _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
    }

    public Task SaveData<T>(string storedProcedure, T parameters)
    {
        return _context.Database.ExecuteSqlRawAsync(storedProcedure, parameters);
    }
}
