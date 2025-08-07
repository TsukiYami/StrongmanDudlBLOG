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

    /*[HttpGet("login/{nID}")]
    public IActionResult Login()
    {
        try
        {
            if(oLoginService.Login())
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }*/
}