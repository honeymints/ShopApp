using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Services.PermissionActions;
using ShopApp.Contracts.PermissionAction;

namespace ShopApp.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly IPermissionActionService _permissionActionService;
    public PermissionController(IPermissionActionService permissionActionService)
    {
        _permissionActionService = permissionActionService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var permissionActionDtos = await _permissionActionService.GetAllPermissionActions();

        return Ok(permissionActionDtos);
    }

    [Authorize]
    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var permissionActionDto = await _permissionActionService.GetPermissionAction(id);

        return Ok(permissionActionDto);
    }
    
    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> Insert(CreatePermissionActionRequest createPermissionActionRequest)
    {
        await _permissionActionService.InsertPermissionAction(
            createPermissionActionRequest.Name, createPermissionActionRequest.Description,
            createPermissionActionRequest.Value, createPermissionActionRequest.CategoryId);

        return Created();
    }

    [Authorize]
    [HttpPut("update")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _permissionActionService.DeletePermissionAction(id);

        return Ok();
    }

    [Authorize]
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _permissionActionService.DeletePermissionAction(id);

        return Ok();
    }

}