using MapsterMapper;
using ShopApp.Application.DTOs;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services;


public class RolePermissionService : IRolePermissionService
{
    private readonly IRolePermissionRepository _rolePermissionRepository;
    private readonly IMapper _mapper;

    public RolePermissionService(IRolePermissionRepository rolePermissionRepository, IMapper mapper)
    {
        _rolePermissionRepository = rolePermissionRepository;
        _mapper = mapper;
    }
    public async Task AssignPermissionsToRole(PermissionsToRoleDto assignPermissionsToRoleDto)
    {

        var rolePermissions = assignPermissionsToRoleDto.PermissionActionIds.Select(
            x => new RolePermission
            {
                PermissionActionId = x,
                RoleId = assignPermissionsToRoleDto.RoleId
            }
        ).ToList();

        foreach (var rolePermission in rolePermissions)
        {
            if (await _rolePermissionRepository.IsExistsWithSuchPermission(
                 rolePermission.RoleId ?? Guid.Empty,
                 rolePermission.PermissionActionId ?? Guid.Empty))
            {
                    throw new Exception("There are already permissions assigned to such role");
            }
        }

        await _rolePermissionRepository.InsertRangeAsync(rolePermissions);
        await _rolePermissionRepository.SaveAsync();

    }

    public async Task<RoleDto> GetRoles()
    {
        throw new NotImplementedException();
    }

    public async Task UnAssignPermissionsFromRole(PermissionsToRoleDto assignPermissionsToRoleDto)
    {
          var rolePermissions = assignPermissionsToRoleDto.PermissionActionIds.Select(
            x => new RolePermission
            {
                PermissionActionId = x,
                RoleId = assignPermissionsToRoleDto.RoleId
            }
        ).ToList();

        foreach (var rolePermission in rolePermissions)
        {
            if (!await _rolePermissionRepository.IsExistsWithSuchPermission(
                 rolePermission.RoleId ?? Guid.Empty,
                 rolePermission.PermissionActionId ?? Guid.Empty))
            {
                    throw new Exception("There are no such permission that assigned to such role");
            }
            await _rolePermissionRepository.DeleteAsync(rolePermission.Id);
        }
        
        await _rolePermissionRepository.SaveAsync();

    }
}