using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities;

public class LoginEntity
{

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
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long nID { get; private set; }

    [Required(ErrorMessage = "Username is required")]
    public string sUsername { get; set; }
    
    [Required(ErrorMessage = "EMail is required")]
    public string sEMail { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    public string sPassword { get; set; }

}