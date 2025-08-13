using BackendStrongmanDudlBLOG.DB;
using BackendStrongmanDudlBLOG.Repositories.Interfaces;
using Entity.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BackendStrongmanDudlBLOG.Repositories;

public class LoginRepository : IRepository<LoginEntity>
{
    private BlogContext oContext;
    private bool bDisposed = false;

    ~LoginRepository()
    {
        Dispose();
    }

    public LoginRepository(BlogContext oContext)
    {
        this.oContext = oContext;
    }

    protected virtual void Disposed(bool bDisposing)
    {
        if(!bDisposed)
            oContext.Dispose();

        bDisposed = true;
    }

    public void Dispose()
    {
        Disposed(true);
        GC.SuppressFinalize(this);
    }

    public IEnumerable<LoginEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public LoginEntity? Get(long nID)
    {
        return oContext.Login.Where(e => e.nID == nID).FirstOrDefault();
    }

    public LoginEntity Get(string sEMail)
    {
        return oContext.Login.Where(e => e.sEMail == sEMail).FirstOrDefault();
    }

    public long Insert(LoginEntity oEntity)
    {
        EntityEntry<LoginEntity> oEntry = oContext.Login.Add(oEntity);
        oContext.SaveChanges();
        return oEntry.Entity.nID;
    }

    public void Delete(long nID)
    {
        LoginEntity oLogin = oContext.Login.Where(e => e.nID == nID).FirstOrDefault();
        oContext.Login.Remove(oLogin);
        oContext.SaveChanges();
    }

    public void Update(LoginEntity oEntity)
    {
        LoginEntity oLogin = oContext.Login.Where(e => e.nID == oEntity.nID).FirstOrDefault();
        oLogin = oEntity;
        oContext.Login.Update(oLogin);
        oContext.SaveChanges();
    }
}