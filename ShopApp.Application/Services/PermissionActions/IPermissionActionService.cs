using ShopApp.Application.DTOs.RolePermissions;

namespace ShopApp.Application.Services.PermissionActions;


public interface IPermissionActionService {

    Task InsertPermissionAction(string name,
        string description,
        int value,
        Guid categoryId);

    Task<List<PermissionActionDto>> GetAllPermissionActions();

    Task<PermissionActionDto> GetPermissionAction(Guid id);

    Task DeletePermissionAction(Guid id);

    Task UpdatePermissionAction(PermissionActionDto permissionActionDto);

    Task CheckIfExists(Guid id);
}