using System.ComponentModel.DataAnnotations;

namespace ShopApp.Contracts.Product;

public record CreateProductRequest
(
    [Required]
    string Name,
    string Description,
    [Required]
    decimal Price
);