namespace MaxCoRetailManager.Application.Contracts.Identity;

public interface IUnitOfWork
{
    int Commit();
    Task<int> CommitAsync();

    IGenericIdentityRepository<T> GetRepositoryIdentity<T>() where T : class;

    void Rollback();

    Task SaveData<T>(string storedProcedure, T parameters);

}
