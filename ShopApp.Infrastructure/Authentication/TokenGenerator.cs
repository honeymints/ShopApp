using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShopApp.Application.Common.Services;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Domain.Entities;
using ShopApp.Application.Persistence;

namespace ShopApp.Infrastructure.Authentication;

public class TokenGenerator : ITokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    private readonly IRolePermissionRepository _rolePermissionRepo;
    public TokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings, IRolePermissionRepository rolePermissionRepository)
    {
        _jwtSettings = jwtSettings.Value;
        _dateTimeProvider = dateTimeProvider;
        _rolePermissionRepo = rolePermissionRepository;
    }
    public string GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.Name)
        };

        //var permissionClaim = _rolePermissionRepo.GetPermissionClaimsByUserAsync();

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: cred
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}