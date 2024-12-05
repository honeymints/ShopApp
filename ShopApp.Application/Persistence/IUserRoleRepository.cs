using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;


public interface IUserRoleRepository
{  
    Task<UserRole?> Get(Guid id);

    Task SaveAsync();
    Task InsertAsync(UserRole userRole);
    
    Task InsertRangeAsync(ICollection<UserRole> userRoles);
    Task DeleteAsync(Guid userId);
    Task DeleteRangeAsync(Guid[] ids);
    
    Task<bool> IsExists(Guid itemId);

    Task<bool> IsUserExistsWithSuchRoles(Guid userId, Guid roleId);

    public Task<Guid[]> GetRolesByUserId(Guid userId);
}