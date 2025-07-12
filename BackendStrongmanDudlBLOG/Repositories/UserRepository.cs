using BackendStrongmanDudlBLOG.DB;
using BackendStrongmanDudlBLOG.Repositories.Interfaces;
using Entity.Entities;

namespace BackendStrongmanDudlBLOG.Repositories;

public class UserRepository : IRepository<LoginEntity>
{
    private BlogContext oContext;
    private bool disposed = false;
}