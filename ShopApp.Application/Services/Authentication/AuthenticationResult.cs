using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services.Authentication;

public record AuthenticationResult( 
    User User,
    string Token
);