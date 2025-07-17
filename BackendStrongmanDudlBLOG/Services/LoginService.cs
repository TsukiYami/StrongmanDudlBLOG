using BackendStrongmanDudlBLOG.DB;
using BackendStrongmanDudlBLOG.Mapper;
using BackendStrongmanDudlBLOG.Repositories;
using Entity.DTOs.Post;
using Entity.Entities;

namespace BackendStrongmanDudlBLOG.Services;

public class LoginService
{
    private LoginRepository oLoginRepository;
    private LoginMapper oLoginMapper;

    public LoginService(BlogContext oContext)
    {
        oLoginRepository = new LoginRepository(oContext);
        oLoginMapper = new LoginMapper();
    }

    public bool PostLogin(PostLoginDTO oPostLoginDTO)
    {
        LoginEntity oLoginEntity = oLoginMapper.PostLoginDTOToEntity(oPostLoginDTO);
        long nID = oLoginRepository.Insert(oLoginEntity);

        if (nID > 1)
        {
            return true;
        }
        
        return false;
    }

    public bool DeleteLogin(long nID)
    {
        if(oLoginRepository.Get(nID) != null)
            oLoginRepository.Delete(nID);
        
        return true;
    }
    
    public LoginEntity GetLogin(long nID)
    {
        return oLoginRepository.Get(nID);
    }

    public (bool, Guid?) Login(long nID)
    {
        LoginEntity oLoginEntity = oLoginRepository.Get(nID);
        return (true, Guid.NewGuid());
    }
}