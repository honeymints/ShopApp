namespace ShopApp.Application.Services.Authentication;

public interface IAuthenticationService {

    AuthenticationResult Login(string Email, string Password);

    AuthenticationResult Register(string Name, string LastName, string Email, string Password);
}