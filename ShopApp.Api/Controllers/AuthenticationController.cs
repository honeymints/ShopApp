namespace ShopApp.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Services.Authentication;
using ShopApp.Contracts.Authentication;

[ApiController]
[Route("/api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService=authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request){

        var authResult =_authenticationService.Register(
            request.Name,
            request.LastName,
            request.Email,
            request.Password);

        var response=new AuthResposne(
            authResult.User.Id,
            authResult.User.Name,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){

       var authResult = _authenticationService.Login(
           request.Email,
           request.Password);
       
       var response=new AuthResposne(
           authResult.User.Id,
           authResult.User.Name,
           authResult.User.LastName,
           authResult.User.Email,
           authResult.Token);
       
       return Ok(response);
    }
}