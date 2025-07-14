namespace BackendStrongmanDudlBLOG.Services.interfaces;

public interface IService<T>
{
    public bool Create(T oObject);
    public List<T> GetAll();
    public T GetByID(long nID);
    public T Update(T oObject);
    public bool DeleteByID(long nID);
}