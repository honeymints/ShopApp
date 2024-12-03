using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Services.Products;
using ShopApp.Contracts.Authentication;
using ShopApp.Application.DTOs.Product;

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
    [HttpPost]
    public async Task<IActionResult> Add(CreateProductRequest createProductRequest)
    {
        var productDto = new ProductDto()
        {
            Name = createProductRequest.Name,
            Description = createProductRequest.Description,
            Price = createProductRequest.Price,
        };
        await _productService.AddProduct(productDto);

        return Created();
    }
}