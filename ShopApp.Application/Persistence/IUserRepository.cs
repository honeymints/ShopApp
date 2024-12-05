using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;

public interface IUserRepository
{
    Task<User?> Get(Guid userId);

    User? GetUserByEmail(string email);


    Task<IReadOnlyCollection<User>> GetAll();
    Task SaveAsync();
    Task InsertAsync(User user);
    
    Task InsertRangeAsync(ICollection<User> user);
    Task DeleteAsync(Guid userId);

    Task DeleteRangeAsync(Guid[] ids);
    
    Task<bool> IsExists(Guid itemId);
    Task UpdateAsync(User user);
}