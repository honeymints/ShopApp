using ShopApp.Domain.Entities;

namespace ShopApp.Application.Common.Interfaces;

public interface ITokenGenerator
{
    public Task<string> GenerateToken(LoginUser loggedInUser, IReadOnlyCollection<PremissionActionClaim> premissionActionClaim);
    
}