using BC = BCrypt.Net.BCrypt;

namespace BusinessLayer.Utils;

public class Hashing
{
    public static string Encode(string password)
    {
        return BC.HashPassword(password);
    }
    
    public static bool Validate(string password, string passwordHash)
    {
        return BC.Verify(password, passwordHash);
    }
}