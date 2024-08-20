namespace MaxCoRetailManager.Application.Contracts.Persistence;

public interface IUnitOfWork
{
    int Commit();
    Task<int> CommitAsync();

    IGenericRepository<T> GetRepository<T>() where T : class;

    void Rollback();

    Task SaveData<T>(string storedProcedure, T parameters);
}
