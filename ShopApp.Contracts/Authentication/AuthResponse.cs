namespace ShopApp.Contracts.Authentication;

public record AuthResposne(
    Guid Id,
    string Name,
    string LastName,
    string Email,
    string Token
);