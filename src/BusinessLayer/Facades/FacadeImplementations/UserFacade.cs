using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using BusinessLayer.Services.Interfaces;
using Domain.Enums;
using Infrastructure.Persistence.UnitOfWork;

namespace BusinessLayer.Facades.FacadeImplementations;

public class UserFacade : FacadeBase, IUserFacade
{
    private readonly IUserService _userService;

    public UserFacade(IUnitOfWorkProvider provider, IUserService userService) : base(provider)
    {
        _userService = userService;
    }

    public async Task<TokenDto> RegisterAsync(UserRegistrationDto userRegistrationDto)
    {
        if (userRegistrationDto == null) throw new ArgumentException("User data can't be null.");

        using (var uow = UnitOfWorkProvider.Create())
        {
            if (_userService.UsernameAlreadyExists(userRegistrationDto.Username))
                throw new ArgumentException("Username already exists.");

            await _userService.CreateAsync(new UserDto
            {
                Name = userRegistrationDto.Name,
                Surname = userRegistrationDto.Surname,
                Username = userRegistrationDto.Username,
                PasswordHash = null,
                Birthdate = default,
                Gender = Gender.Male,
                Height = 0,
                Weight = 0,
                Bio = null,
                Longitude = 0,
                Latitude = 0,
                Chats = null,
                BlockedUsers = null,
                Friendships = null,
                Preferences = null,
                Photos = null
            });

            await uow.CommitAsync();
        }

        return new TokenDto
        {
            Token = "xxx"
        };
    }
}