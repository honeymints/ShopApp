namespace ShopApp.Application.Common.Services;

public class PasswordHasher
{
    private const int SaltSize = 12;
    
    private static string GenerateSalt()
    {
        return BCrypt.Net.BCrypt.GenerateSalt(SaltSize);
    }

    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt());
    }

    public static bool VerifyHashedPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}