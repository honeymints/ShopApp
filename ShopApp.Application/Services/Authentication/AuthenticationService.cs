using ShopApp.Application.Interfaces;

namespace ShopApp.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITokenGenerator _tokenGenerator;
    public AuthenticationService(ITokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }
    
    public AuthenticationResult Login(string Email, string Password)
    {   
        var userId = new Guid();
        var token = _tokenGenerator.GenerateToken(userId, Email);
            
        return new AuthenticationResult(
            userId,
            "name",
            "lastname",
            Email,
            token
            );
    }

    public AuthenticationResult Register(string Name, string LastName, string Email, string Password)
    {
        var userId = new Guid();
        var token = _tokenGenerator.GenerateToken(userId, Email);
            
       return new AuthenticationResult(
           userId,
            Name,
            LastName,
            Email,
            token
       );
    }
}
