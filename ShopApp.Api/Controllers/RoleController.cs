using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.DTOs.Role;
using ShopApp.Application.Services;
using ShopApp.Contracts.Role;

namespace ShopApp.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
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
}