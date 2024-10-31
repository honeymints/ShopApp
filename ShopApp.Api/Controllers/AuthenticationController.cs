using Serilog;
using ShopApp.Api.Filters;

namespace ShopApp.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Services.Authentication;
using ShopApp.Contracts.Authentication;

[ApiController]
[Route("/api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService,
        ILogger<AuthenticationController> logger)
    {
        _authenticationService=authenticationService;
        _logger = logger;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request){

        _logger.LogInformation(
            "Proccessing request: {1}", request);
        
        var authResult =_authenticationService.Register(
            request.Name,
            request.LastName,
            request.Email,
            request.Password);

        _logger.LogInformation(
            "User has been registrated successfully: {1}", authResult);
        
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

        _logger.LogInformation(
            "Proccessing request: {1}", request);
        
       var authResult = _authenticationService.Login(
           request.Email,
           request.Password);
       
       _logger.LogInformation(
           "User has been authenticated successfully: {1}", authResult);
       
       var response=new AuthResposne(
           authResult.User.Id,
           authResult.User.Name,
           authResult.User.LastName,
           authResult.User.Email,
           authResult.Token);
       
       return Ok(response);
    }
}