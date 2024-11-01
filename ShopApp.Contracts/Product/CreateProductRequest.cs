namespace ShopApp.Contracts.Authentication;

public record CreateProductRequest
(
    string Name,
    string Description,
    decimal Price
);