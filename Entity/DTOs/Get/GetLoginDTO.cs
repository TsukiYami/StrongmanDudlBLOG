namespace Entity.DTOs.Get;

public class GetLoginDTO
{
    public GetLoginDTO(string sUsername, string sEMail, byte[] nPassword)
    {
        this.sUsername = sUsername;
        this.sEMail = sEMail;
        this.nPassword = nPassword;
    }

    public string sUsername { get; private set; }
    public string sEMail { get; private set; }
    public byte[] nPassword { get; private set; }
}