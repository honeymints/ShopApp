using ShopApp.Domain;

namespace ShopApp.Application.Services.Authentication;

public record AuthenticationResult( 
    User User,
    string Token
);