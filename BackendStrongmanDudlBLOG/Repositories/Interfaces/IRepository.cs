namespace BackendStrongmanDudlBLOG.Repositories.Interfaces;

public interface IRepository<T> : IDisposable
{
    IEnumerable<T> GetAll();
    T? Get(long nID);
    long Insert(T oEntity);
    void Delete(long nID);
    void Update(T oEntity);
}