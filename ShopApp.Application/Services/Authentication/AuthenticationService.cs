namespace ShopApp.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "name",
            "lastname",
            Email,
            Password);
    }

    public AuthenticationResult Register(string Name, string LastName, string Email, string Password)
    {
       return new AuthenticationResult(
        Guid.NewGuid(),
        Name,
        LastName,
        Email,
        Password);
    }
}
