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

    [Required(ErrorMessage = "Username is required")]
    public string sUsername { get; set; }
    
    [Required(ErrorMessage = "EMail is required")]
    public string sEMail { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    public string sPassword { get; set; }
}