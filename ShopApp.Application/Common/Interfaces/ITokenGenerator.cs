using ShopApp.Domain;

namespace ShopApp.Application.Interfaces;

public interface ITokenGenerator
{
    public string GenerateToken(User user);
    
}