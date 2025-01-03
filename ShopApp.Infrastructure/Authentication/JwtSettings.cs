namespace ShopApp.Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string Issuer { get; init; } =null!;
    public string Audience { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
    public string Secret { get; init;} = null!;

    public static string PrivateKey {get;} =null!;
}