using ShopApp.Application.DTOs.Role;

namespace ShopApp.Application.Services;


public interface IRoleService
{
    Task<List<RoleDto>> GetAllRoles();

    Task<RoleDto> GetRoleById(Guid roleId);

    // Task<List<RoleDto>> GetRolesByUserId(Guid userId);

    Task CreateRole(CreateRoleDto roleDto);
    Task UpdateRole(RoleDto roleDto);

    Task DeleteRole(Guid id);

    Task<bool> IsExists(Guid id);

}