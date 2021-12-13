using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Facades.FacadeInterfaces;

public interface IUserFacade : IDisposable
{
    Task<string> RegisterAsync(UserRegistrationDto userRegistrationDto);
}