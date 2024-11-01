namespace ShopApp.Contracts.Authentication;

public record ProductDto
(   Guid Id,
    string Name,
    string Description,
    decimal Price
);