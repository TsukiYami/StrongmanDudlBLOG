using BackendStrongmanDudlBLOG.Services;
using Entity;
using Entity.DTOs.Post;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendStrongmanDudlBLOG.Controllers;

[Route("/api/Login")]
[ApiController]
public class LoginController : ControllerBase
{
    private LoginService oLoginService;

    public LoginController(LoginService oLoginService)
    {
        this.oLoginService = oLoginService;
    }

    [HttpPost("RegisterUser")]
    public IActionResult Register(PostLoginDTO oPostLoginDTO)
    {
        string sHeaderBody = Request.Headers[RequestValues.HEADER_BODY];
        oPostLoginDTO = JsonConvert.DeserializeObject<PostLoginDTO>(sHeaderBody);

        if (oLoginService.Register(oPostLoginDTO))
        {
            return Created();
        }
        
        return BadRequest();
    }
}