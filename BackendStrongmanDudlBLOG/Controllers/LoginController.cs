using BackendStrongmanDudlBLOG.Services;
using Entity;
using Entity.DTOs.Post;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendStrongmanDudlBLOG.Controllers;

[Route("/api/")]
[ApiController]
public class LoginController : ControllerBase
{
    private LoginService oLoginService;

    public LoginController(LoginService oLoginService)
    {
        this.oLoginService = oLoginService;
    }

    [HttpPost("register/")]
    public IActionResult Register()
    {
        /*string sHeaderBody = Request.Headers[RequestValues.HEADER_BODY];
        oPostLoginDTO = JsonConvert.DeserializeObject<PostLoginDTO>(sHeaderBody);

        if(oPostLoginDTO == null)
            return BadRequest();
        if (oLoginService.Register(oPostLoginDTO))
            return Created("", "User registered successfully");
        
        return BadRequest("Registration failed");*/
        try
        {
            string sHeaderBody = Request.Headers[RequestValues.HEADER_BODY];
            
            if (string.IsNullOrEmpty(sHeaderBody))
                return BadRequest("No data provided in header");
                
            PostLoginDTO oPostLoginDTO = JsonConvert.DeserializeObject<PostLoginDTO>(sHeaderBody);

            if(oPostLoginDTO == null)
                return BadRequest("Invalid data format");
                
            if (oLoginService.Register(oPostLoginDTO))
                return Created("", "User registered successfully");
            
            return BadRequest("Registration failed");
        }
        catch (JsonException)
        {
            return BadRequest("Invalid JSON format");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

    }
}