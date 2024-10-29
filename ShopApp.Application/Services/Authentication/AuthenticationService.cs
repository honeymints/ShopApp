using ShopApp.Application.Interfaces;
using ShopApp.Application.Persistence;
using ShopApp.Domain;

namespace ShopApp.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(ITokenGenerator tokenGenerator, IUserRepository userRepository)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
    }
    
    public AuthenticationResult Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);
        if (user is null)
        {
            throw new Exception("no such user exist with given email");
        }
        
        var token = _tokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token
        );
    }

    public AuthenticationResult Register(string name, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User already exists!");
        }
        var user = new User
        {
            Email = email,
            Name = name,
            LastName = lastName,
            Password = password,
        };
            
        _userRepository.InsertUser(user);
        var token = _tokenGenerator.GenerateToken(user);
            
        return new AuthenticationResult(
            user,
            token
        );
        
    }
}
