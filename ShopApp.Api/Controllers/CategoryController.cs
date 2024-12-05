using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Attributes;
using ShopApp.Application.Services.Category;
using ShopApp.Application.Services.ProductCategories;
using ShopApp.Contracts.Category;
using ShopApp.Domain.Enums;

namespace ShopApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IProductCategoryService _productCategoryService;

    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService, IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;

        _categoryService = categoryService;
    }

      [Authorize]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var productResult = await _categoryService.GetAllCategories();

        return Ok(productResult);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    
    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var productDto = await _categoryService.GetCategoryById(id);

        return Ok(productDto);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("create")]
    [Permission(PermissionActionEnum.CreateProduct)]
    public async Task<IActionResult> Create(CreateCategoryRequest createCategoryRequest)
    {
        await _categoryService.CreateCategory(
            createCategoryRequest.Name,
            createCategoryRequest.Description);

        return Created();
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpDelete("delete/{id}")]
    [Permission(PermissionActionEnum.DeleteProduct)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _categoryService.DeleteCategory(id);

        return Accepted();
    }

    // [Authorize(AuthenticationSchemes = "Bearer")]
    // [HttpPut("update")]
    // [Permission(PermissionActionEnum.UpdateCategory)]
    // public async Task<IActionResult> Update(UpdateCategoryRequest updateProductRequest)
    // {
    //     await _categoryService.UpdateCategory(
    //         updateProductRequest.Id,
    //         updateProductRequest.Name,
    //         updateProductRequest.Description);

    //     return Ok();
    // }
}