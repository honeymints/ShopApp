using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShopApp.Application.Common.Services;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Domain.Entities;
using ShopApp.Application.Persistence;
using Newtonsoft.Json;

namespace ShopApp.Infrastructure.Authentication;

public class TokenGenerator : ITokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public TokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
        _dateTimeProvider = dateTimeProvider;
    }
    public async Task<string> GenerateToken(User user, PermissionsClaim premissionsClaim)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.Name)
        };
               
        var permissionJson = JsonConvert.SerializeObject(premissionsClaim);

        claims.Add(new Claim("Permissions", permissionJson));

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