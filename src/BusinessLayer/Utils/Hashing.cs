using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.Utils;

public class Hashing
{
    public static string Encode(string password)
    {
        var inputAsBytes = Encoding.ASCII.GetBytes(password);
        var hashAlg = new HMACSHA256();
        return Convert.ToHexString(hashAlg.ComputeHash(inputAsBytes));
    }
    
    public static bool Validate(string password, string passwordHash)
    {
        var hashedPassword = Encode(password);
        return string.Equals(hashedPassword, passwordHash, StringComparison.CurrentCultureIgnoreCase);
    }
}