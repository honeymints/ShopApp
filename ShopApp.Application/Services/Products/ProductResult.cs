using ShopApp.Application.Persistence.DTOs;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services.Products;

public record ProductResult(
    List<ProductDto> Product
    );