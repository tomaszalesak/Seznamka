using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Facades.FacadeInterfaces;

public interface IUserFacade : IDisposable
{
    Task<TokenDto> RegisterAsync(UserRegistrationDto userRegistrationDto);
}