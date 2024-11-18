using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Services;

namespace ShopApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolePermissionController : ControllerBase
{
    private readonly IRolePermissionService _rolePermissionService;
    public RolePermissionController(IRolePermissionService rolePermissionService)
    {
        _rolePermissionService = rolePermissionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

    }

    public async Task<IActionResult> Create()
    {

    }
}