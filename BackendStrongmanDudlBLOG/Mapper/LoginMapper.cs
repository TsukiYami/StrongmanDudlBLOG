using Entity.DTOs.Get;
using Entity.DTOs.Post;
using Entity.DTOs.Put;
using Entity.Entities;

namespace BackendStrongmanDudlBLOG.Mapper;

public class LoginMapper
{
    public LoginEntity PostLoginDTOToEntity(PostLoginDTO oPostLoginDTO)
    {
        return new LoginEntity(oPostLoginDTO.sUsername, oPostLoginDTO.sEMail, oPostLoginDTO.sPassword);
    }

    public GetLoginDTO EntityToGetLoginDTO(LoginEntity oLoginEntity)
    {
        GetLoginDTO oDTO = new(
            oLoginEntity.sUsername,
            oLoginEntity.sEMail,
            oLoginEntity.sPassword);
        
        return oDTO;
    }

    public LoginEntity PutLoginDTOToEntity(PutLoginDTO oPutLoginDTO)
    {
        return new LoginEntity(oPutLoginDTO.sUsername, oPutLoginDTO.sEMail, oPutLoginDTO.sPassword);
    }
}