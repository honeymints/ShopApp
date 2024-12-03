using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;


public interface IUserRoleRepository
{  
    Task<UserRole?> FindById(Guid userId);

    Task SaveAsync();
    Task InsertAsync(UserRole userRoles);
    
    Task InsertRangeAsync(ICollection<UserRole> userRoles);
    Task DeleteAsync(Guid userId);
    
    Task<bool> IsExists(Guid itemId);

    Task<bool> IsUserExistsWithSuchRoles(Guid userId, Guid roleId);

    public Task<Guid[]> FindRolesByUserId(Guid userId);
}