using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.DTOs.Role;
using ShopApp.Application.DTOs.RolePermissions;
using ShopApp.Application.Services;
using ShopApp.Contracts.Role;
using ShopApp.Contracts.RolePermission;

namespace ShopApp.Api.Controllers;


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

     [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var role = await _roleService.GetRoleById(id);

        return Ok(role);
    }

    [HttpPut]
    public async Task<IActionResult> AssignPermissions(RolePermissionInputRequest rolePermissionInputRequest)
    {
        var permissionsToRoleDto = new PermissionsToRoleDto
        {
            RoleId = rolePermissionInputRequest.roleId,
            PermissionActionIds = rolePermissionInputRequest.permissionActionIds
        };

        await _rolePermissionService.AssignPermissionsToRole(permissionsToRoleDto);

        return Ok();
    }
}