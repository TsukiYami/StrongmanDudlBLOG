using Entity.DTOs.Post;
using Entity.Entities;

namespace BackendStrongmanDudlBLOG.Mapper;

public class LoginMapper
{
    public LoginEntity PostLoginDTOToEntity(PostLoginDTO oPostLoginDTO)
    {
        return new LoginEntity(oPostLoginDTO.sUsername, oPostLoginDTO.sEMail, oPostLoginDTO.sPassword);
    }
}