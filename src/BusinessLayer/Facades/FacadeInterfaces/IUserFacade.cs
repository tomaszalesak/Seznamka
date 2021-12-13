﻿using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Facades.FacadeInterfaces;

public interface IUserFacade : IDisposable
{
    Task<string> RegisterAsync(UserRegistrationDto userRegistrationDto);
    
    string LoginAsync(UserLoginDto userLoginDto);

    IList<UserDto> GetAllPossiblePartners(string usernameToOmit, int requestedPage,
        bool filterByAge, bool filterByHeight, bool filterByWeight, int pageSize);
}