using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services.Authentication;

public record AuthenticationResult( 
    LoginUser User,
    string Token
);