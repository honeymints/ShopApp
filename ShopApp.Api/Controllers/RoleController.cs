using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Attributes;
using ShopApp.Application.DTOs.Role;
using ShopApp.Application.Services;
using ShopApp.Contracts.Role;
using ShopApp.Contracts.RolePermission;
using ShopApp.Domain.Enums;

namespace ShopApp.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    private readonly IRolePermissionService _rolePermissionService;
    public RoleController(IRoleService roleService, IRolePermissionService rolePermissionService)
    {
        _roleService = roleService;
        _rolePermissionService = rolePermissionService;
    }

    [Permission(PermissionActionEnum.CreateRole)]
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateRoleRequest createRoleRequest)
    {
        var roleDto = new CreateRoleDto
        {
            Name = createRoleRequest.Name,
            Description = createRoleRequest.Description
        };

        await _roleService.CreateRole(roleDto);

        return Created();
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var roles =  await _roleService.GetAllRoles();

        return Ok(roles);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var role = await _roleService.GetRoleById(id);

        return Ok(role);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _roleService.DeleteRole(id);

        return Ok();
    }

    
    [HttpPut("assign-permissions")]
    public async Task<IActionResult> AssignPermissions(RolePermissionInputRequest rolePermissionInputRequest)
    {
        await _rolePermissionService.AssignPermissionsToRole(
            rolePermissionInputRequest.roleId,
            rolePermissionInputRequest.permissionActionIds);
        return Ok();
    }

    [HttpPut("unassign-permissions")]
    public async Task<IActionResult> UnAssignPermissions(RolePermissionInputRequest rolePermissionInputRequest)
    {
        await _rolePermissionService.UnAssignPermissionsFromRole(
            rolePermissionInputRequest.roleId,
            rolePermissionInputRequest.permissionActionIds);

        return Ok();
    }
}