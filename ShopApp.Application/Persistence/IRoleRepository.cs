using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;


public interface IRoleRepository
{
    Task<Role?> FindById(Guid roleId);

    Task<IReadOnlyCollection<Role>> GetAll();
    Task SaveAsync();
    Task InsertAsync(Role role);
    
    Task InsertRangeAsync(ICollection<Role> roles);
    Task DeleteAsync(Guid roleId);
    
    Task<bool> IsExists(Guid itemId);

    Task<bool> IsExists(string Name);
    Task UpdateAsync(Role role);

}