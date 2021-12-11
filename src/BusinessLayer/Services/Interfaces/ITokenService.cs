using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Services.Interfaces;

public interface ITokenService
{
    string BuildToken(string key, string issuer, UserDto user);
}