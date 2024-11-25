using MapsterMapper;
using ShopApp.Application.DTOs.RolePermissions;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services;


public class RolePermissionService : IRolePermissionService
{
    private readonly IRolePermissionRepository _rolePermissionRepository;

    private readonly IPermissionActionRepository _permissionActionRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public RolePermissionService(IRolePermissionRepository rolePermissionRepository, 
    IPermissionActionRepository permissionActionRepository,
    IRoleRepository roleRepository, IMapper mapper)
    {
        _rolePermissionRepository = rolePermissionRepository;
        _permissionActionRepository = permissionActionRepository;
        _roleRepository = roleRepository;
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
            if(!await _roleRepository.IsExists(rolePermission.RoleId ?? Guid.Empty) && 
            !await _permissionActionRepository.IsExists(rolePermission.PermissionActionId ?? Guid.Empty))
            {
                throw new Exception("Such role or permission doesn't exist");
            }


            if (await _rolePermissionRepository.IsRoleExistsWithSuchPermission(
                 rolePermission.RoleId ?? Guid.Empty,
                 rolePermission.PermissionActionId ?? Guid.Empty))
            {
                throw new Exception("There are already permissions assigned to such role");
            }
        }

        await _rolePermissionRepository.InsertRangeAsync(rolePermissions);
        await _rolePermissionRepository.SaveAsync();

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

        
            if (!await _rolePermissionRepository.IsRoleExistsWithSuchPermission(
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