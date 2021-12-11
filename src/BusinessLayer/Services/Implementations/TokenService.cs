using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer.Services.Implementations;

public class TokenService : ITokenService
{
    private readonly TimeSpan _expiryDuration = new(0, 30, 0);
    public string BuildToken(string key, string issuer, UserDto user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier,
                Guid.NewGuid().ToString())
        };
 
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
            expires: DateTime.Now.Add(_expiryDuration), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}