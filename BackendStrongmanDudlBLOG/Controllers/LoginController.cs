using BackendStrongmanDudlBLOG.Caches;
using BackendStrongmanDudlBLOG.Services;
using Entity;
using Entity.DTOs.Post;
using Entity.Entities;
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
    public IActionResult Register([FromBody] PostLoginDTO oPostLoginDTO)
    {
        try
        {
            if(oPostLoginDTO == null)
                return BadRequest("Invalid data format");
            
            if(oLoginService.Register(oPostLoginDTO))
                return Created("", "User registered successfully");
            
            return BadRequest("Registration failed");
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpGet("login/")]
    public IActionResult Login([FromBody] string sEMail, [FromBody] string sPassword)
    {
        sEMail = Request.Headers[RequestValues.HEADER_EMAIL];
        sPassword = Request.Headers[RequestValues.HEADER_PASSWORD];
        
        if(String.IsNullOrEmpty(sEMail) || String.IsNullOrEmpty(sPassword))
            return BadRequest("Invalid data format");
        
        (bool, Guid?) oResult = oLoginService.Login(sEMail, sPassword);
        if(oResult.Item1)
            return Ok(oResult.Item2);
        
        return Unauthorized(oResult.Item2);
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        string sToken = Request.Headers[RequestValues.HEADER_TOKEN];
        
        LogedInUserCache.Remove(Guid.Parse(sToken));
        
        return BadRequest();
    }

    [HttpDelete("delete/{nID}")]
    public IActionResult Delete(long nID)
    {
        if (oLoginService.DeleteLogin(nID) == false)
        {
            return BadRequest("Deletion failed");
        }
        return BadRequest();
    }
}