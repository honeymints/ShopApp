using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Services.Products;
using ShopApp.Contracts.Authentication;
using ShopApp.Domain.Entities;

namespace ShopApp.Api.Controllers;

[Route("/api/product")]
public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(IProductService productService, ILogger<ProductController> logger)
    {
        _productService = productService;
        _logger = logger;
    }
    
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var productResult = await _productService.GetProducts();

        var productDto = productResult.Select
            (p => new ProductDto(
            Id:p.Id,
            Name: p.Name,
            Description: p.Description,
            Price: p.Price
        )).ToList();
                    
        var response = new ProductResponse(productDto);
        
        return Ok(response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var product = await _productService.GetProductById(id);

        var productDto = new ProductDto
        (
            Id: product.Id,
            Description: product.Description,
            Price: product.Price,
            Name: product.Name
        );

        return Ok(productDto);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Add(CreateProductRequest createProductRequest)
    {
        var product = new Product()
        {
            Name = createProductRequest.Name,
            Description = createProductRequest.Description,
            Price = createProductRequest.Price,

        };
        await _productService.AddProduct(product);
        
        return Created();
    }
}