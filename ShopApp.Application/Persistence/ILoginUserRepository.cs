using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;


public interface ILoginUserRepository {

    Task<IReadOnlyCollection<LoginUser>> GetAll();
    Task SaveAsync();
    Task InsertAsync(LoginUser loginUser);
    
    Task InsertRangeAsync(ICollection<LoginUser> loginUser);
    Task DeleteAsync(Guid userId);
    
    Task<bool> IsExists(Guid itemId);
    Task UpdateAsync(LoginUser loginUser);

    Task<bool> IsUserLoggedIn(string email);

}