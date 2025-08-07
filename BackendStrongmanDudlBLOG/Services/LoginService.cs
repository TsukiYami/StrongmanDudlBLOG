using BackendStrongmanDudlBLOG.DB;
using BackendStrongmanDudlBLOG.Mapper;
using BackendStrongmanDudlBLOG.Repositories;
using Entity.DTOs.Post;
using Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace BackendStrongmanDudlBLOG.Services;

public class LoginService
{
    private LoginRepository oLoginRepository;
    private readonly BlogContext oContext;

    public LoginService(BlogContext oContext)
    {
        oLoginRepository = new LoginRepository(oContext);
        this.oContext = oContext;
    }

    public bool Register(PostLoginDTO oPostLoginDTO)
    {
        try
        {
            var user = new LoginEntity
            {
                sUsername = oPostLoginDTO.sUsername,
                sEMail = oPostLoginDTO.sEMail,
                sPassword = oPostLoginDTO.sPassword
            };
            oContext.Login.Add(user);
            int nResult = oContext.SaveChanges();
            return nResult > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
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

    public (bool, Guid?) Login(string sUsername, string sEMail, string sPassword)
    {
        LoginEntity oLoginEntity = oLoginRepository.Get(sUsername, sEMail);
        if (oLoginEntity.sPassword == sPassword)
        {
            Guid oGUID = Guid.NewGuid();
            return (true, oGUID);
        }
        return (false, null);
    }
}