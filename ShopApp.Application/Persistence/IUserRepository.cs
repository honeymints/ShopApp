using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;

public interface IUserRepository
{
    Task<User?> FindById(Guid userId);

    User? GetUserByEmail(string email);

    Task SaveAsync();

    Task InsertAsync(User user);
    
    Task<IEnumerable<User>> GetAll();
    Task InsertRangeAsync(IEnumerable<User> product);
    Task DeleteAsync(Guid userId);
    
    Task<bool> IsExists(Guid itemId);
    Task UpdateAsync(User user);
}