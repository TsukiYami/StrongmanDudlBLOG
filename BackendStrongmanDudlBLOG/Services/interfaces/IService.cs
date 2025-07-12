namespace BackendStrongmanDudlBLOG.Services.interfaces;

public interface IService<T>
{
    public bool Create(T oObject);
    public List<T> GetAll();
    public T GetByID(Guid nID);
    public T Update(T oObject);
    public bool DeleteByID(Guid nID);
}