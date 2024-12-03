using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services.UserRoles;


public interface IUserRoleService
{
    Task AssignRolesToUser(Guid userId, Guid[] roleIds);

    Task UnAssignRolesFromUser(Guid userId, Guid[] roleIds);

    Task CheckIfExists(UserRole userRole);
}