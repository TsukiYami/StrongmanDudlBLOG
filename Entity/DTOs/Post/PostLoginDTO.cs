namespace Entity.DTOs.Post;

public class PostLoginDTO
{
    public PostLoginDTO(string sUsername, string sEMail, byte[] sPassword)
    {
        this.sUsername = sUsername;
        this.sEMail = sEMail;
        this.sPassword = sPassword;
    }

    public string sUsername { get; private set; }
    public string sEMail { get; private set; }
    public byte[] sPassword { get; private set; }
}