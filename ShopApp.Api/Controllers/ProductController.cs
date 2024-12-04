using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Services.Products;
using ShopApp.Domain.Enums;
using ShopApp.Application.Attributes;
using ShopApp.Contracts.Product;

namespace ShopApp.Api.Controllers;

[ApiController]
[Route("/api/product")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(IProductService productService, ILogger<ProductController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    [Authorize]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var productResult = await _productService.GetProducts();

        return Ok(productResult);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    
    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var productDto = await _productService.GetProductById(id);

        return Ok(productDto);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("create")]
    [Permission(PermissionActionEnum.CreateProduct)]
    public async Task<IActionResult> Create(CreateProductRequest createProductRequest)
    {
        await _productService.AddProduct(
            createProductRequest.Name,
            createProductRequest.Description,
            createProductRequest.Price);

        return Created();
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpDelete("delete/{id}")]
    [Permission(PermissionActionEnum.DeleteProduct)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _productService.DeleteProduct(id);

        return Accepted();
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPut("update")]
    [Permission(PermissionActionEnum.UpdateProduct)]
    public async Task<IActionResult> Update(UpdateProductRequest updateProductRequest)
    {
        await _productService.UpdateProduct(
            updateProductRequest.Id,
            updateProductRequest.Name,
            updateProductRequest.Description,
            updateProductRequest.Price,
            updateProductRequest.ProductCategoryIds);

        return Ok();
    }
}