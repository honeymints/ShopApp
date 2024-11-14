namespace ShopApp.Application.Services.Authentication;

public interface IAuthenticationService {

    Task<AuthenticationResult> Login(string Email, string Password);

    Task<AuthenticationResult> Register(string Name, string LastName, string Email, string Password);
}