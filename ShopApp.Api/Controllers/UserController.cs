using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Services.UserRoles;
using ShopApp.Contracts.UserRole;

namespace ShopApp.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase {

    private readonly IUserRoleService _userRoleService;
    public UserController(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    [HttpPut("assign-roles")]
    public async Task<IActionResult> AssignPermissions(UserRoleInputRequest userRoleInputRequest)
    {
        await _userRoleService.AssignRolesToUser(
            userRoleInputRequest.userId,
            userRoleInputRequest.roleIds);
        return Ok();
    }

    
    [HttpPut("unassign-roles")]
    public async Task<IActionResult> UnAssignPermissions(UserRoleInputRequest userRoleInputRequest)
    {
        await _userRoleService.UnAssignRolesFromUser(
            userRoleInputRequest.userId,
            userRoleInputRequest.roleIds);

        return Ok();
    }
}