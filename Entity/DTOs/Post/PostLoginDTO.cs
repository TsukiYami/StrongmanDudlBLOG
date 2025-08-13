using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs.Post;

public class PostLoginDTO
{
    public PostLoginDTO(string sUsername, string sEMail, string sPassword)
    {
        this.sUsername = sUsername;
        this.sEMail = sEMail;
        this.sPassword = sPassword;
    }
    
    public string sUsername { get; private set; }
    
    public string sEMail { get; private set; }
    
    public string sPassword { get; private set; }
}