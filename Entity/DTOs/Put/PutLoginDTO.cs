namespace Entity.DTOs.Put;

public class PutLoginDTO
{
    public PutLoginDTO(string sUsername, string sEMail, string sPassword)
    {
        this.sUsername = sUsername;
        this.sEMail = sEMail;
        this.sPassword = sPassword;
    }

    public string sUsername { get; private set; }
    public string sEMail { get; private set; }
    public string sPassword { get; private set; }
}