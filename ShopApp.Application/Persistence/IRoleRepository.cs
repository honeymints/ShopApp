using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;


public interface IRoleRepository
{
    Task<Role?> Get(Guid id);

    Task<IReadOnlyCollection<Role>> GetAll();
    Task SaveAsync();
    Task InsertAsync(Role role);
    
    Task InsertRangeAsync(ICollection<Role> roles);
    Task DeleteAsync(Guid id);
    
    Task<bool> IsExists(Guid id);

    Task<bool> IsExists(string Name);
    Task UpdateAsync(Role role);

}