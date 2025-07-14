using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities;

public class LoginEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long nID { get; private set; }

    public LoginEntity(long nId, string sUsername, string sEMail, byte[] sPassword)
    {
        nID = nId;
        this.sUsername = sUsername;
        this.sEMail = sEMail;
        this.sPassword = sPassword;
    }

    public string sUsername { get; private set; }
    public string sEMail { get; private set; }
    public byte[] sPassword { get; private set; }

    public LoginEntity(string sUsername, string sEMail, byte[] sPassword)
    {
        this.sUsername = sUsername;
        this.sEMail = sEMail;
        this.sPassword = sPassword;
    }
}