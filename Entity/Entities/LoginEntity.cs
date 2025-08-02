using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities;

public class LoginEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long nID { get; private set; }

    public LoginEntity(long nId, string sUsername, string sEMail, string sPassword)
    {
        nID = nId;
        this.sUsername = sUsername;
        this.sEMail = sEMail;
        this.sPassword = sPassword;
    }
    public LoginEntity(string sUsername, string sEMail, string sPassword)
    {
        this.sUsername = sUsername;
        this.sEMail = sEMail;
        this.sPassword = sPassword;
    }
    public LoginEntity() { }

    public string sUsername { get; set; }
    public string sEMail { get; set; }
    public string sPassword { get; set; }

}