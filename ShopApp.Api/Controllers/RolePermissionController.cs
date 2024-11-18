using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Services;

namespace ShopApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{

    private readonly IRolePermissionService _rolePermissionService;
    public RoleController(IRolePermissionService rolePermissionService)
    {
        _rolePermissionService = rolePermissionService;
    }

    [Route("")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        
    }

    public async Task<IActionResult>
}