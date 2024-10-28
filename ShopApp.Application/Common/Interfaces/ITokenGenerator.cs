namespace ShopApp.Application.Interfaces;

public interface ITokenGenerator
{
    public string GenerateToken(Guid userId, string email);
    
}