using ShopApp.Application.Common.Services;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using System.Security.Claims;

namespace ShopApp.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    private readonly ILoginUserRepository _loginUserRepository;

    private readonly IRolePermissionRepository _rolePermissionRepo;
    public AuthenticationService(ITokenGenerator tokenGenerator,
     IUserRepository userRepository, ILoginUserRepository loginUserRepository,
     IRolePermissionRepository rolePermissionRepository)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
        _loginUserRepository = loginUserRepository;
        _rolePermissionRepo = rolePermissionRepository;
    }

    public async Task<AuthenticationResult> Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);


        if (user is null)
        {
            throw new Exception("no such user exist with given email");
        }

        if (!PasswordHasher.VerifyHashedPassword(password, user.Password))
        {
            throw new Exception("incorrect password!");
        }

        var isUserLoggedIn = await _loginUserRepository.IsUserLoggedIn(email);

        if (isUserLoggedIn)
        {
            throw new Exception("You're already logged in!");
        }

        var loginUser = new LoginUser
        {
            Email = user.Email,
            Name = user.Name,
            UserId = user.Id,
            LastName = user.LastName
        };
        var permissionClaim = await _rolePermissionRepo.GetPermissionClaimsByUserAsync(loginUser);
        var token = await _tokenGenerator.GenerateToken(loginUser, permissionClaim);

        loginUser.Token = token;

        await _loginUserRepository.InsertAsync(loginUser);
        await _userRepository.SaveAsync();

        return new AuthenticationResult(
            loginUser,
            token
        );
    }

    public async Task<AuthenticationResult> Register(string name, string lastName, string email, string password)
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
            Password = PasswordHasher.HashPassword(password),
        };

        await _userRepository.InsertAsync(user);
        await _userRepository.SaveAsync();

        var loginUser = new LoginUser
        {
            Email = user.Email,
            Name = user.Name,
            UserId = user.Id,
            LastName = user.LastName
        };

        var permissionClaim = await _rolePermissionRepo.GetPermissionClaimsByUserAsync(loginUser);
        var token = await _tokenGenerator.GenerateToken(loginUser, permissionClaim);

        loginUser.Token = token;

        await _loginUserRepository.InsertAsync(loginUser);
        await _userRepository.SaveAsync();

        return new AuthenticationResult(
            loginUser,
            token
        );

    }
}
