namespace ShopApp.Api.Controllers;

using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request){

        return Ok(request);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){

        return Ok(request);
    }
}