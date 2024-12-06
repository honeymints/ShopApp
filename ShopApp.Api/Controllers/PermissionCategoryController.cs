using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Services.PermissionCategories;
using ShopApp.Contracts.PermissionCategory;


namespace ShopApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionCategoryController : ControllerBase
{
    private readonly IPermissionCategoryService _permissionCategoryService;
    public PermissionCategoryController(IPermissionCategoryService permissionCategoryServcie)
    {
        _permissionCategoryService = permissionCategoryServcie;
    }

    [Authorize]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var productResult = await _permissionCategoryService.GetAll();

        return Ok(productResult);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var productDto = await _permissionCategoryService.GetById(id);

        return Ok(productDto);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("create")]
    public async Task<IActionResult> Create(PermissionCategoryRequest permissionCategoryRequestRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _permissionCategoryService.CreatePermissionCategory(
             permissionCategoryRequestRequest.Name,
             permissionCategoryRequestRequest.Description,
             permissionCategoryRequestRequest.Value);

        return Created();
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpDelete("delete/{id}")]
    // [Permission(PermissionActionEnum.DeleteProduct)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _permissionCategoryService.DeletePermissionCategory(id);
        return Accepted();
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(Guid Id, PermissionCategoryRequest permissionCategoryRequestRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _permissionCategoryService.UpdatePermissionCategory(
            Id,
            permissionCategoryRequestRequest.Name,
            permissionCategoryRequestRequest.Description,
            permissionCategoryRequestRequest.Value);

        return Ok();
    }
}