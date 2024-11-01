using ShopApp.Domain.Entities;

namespace ShopApp.Application.Common.Interfaces;

public interface ITokenGenerator
{
    public string GenerateToken(User user);
    
}