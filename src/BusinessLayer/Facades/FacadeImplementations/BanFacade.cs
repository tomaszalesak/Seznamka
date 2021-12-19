using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using BusinessLayer.Services.Interfaces;
using Infrastructure.Persistence.UnitOfWork;

namespace BusinessLayer.Facades.FacadeImplementations;

public class BanFacade : FacadeBase, IBanFacade
{
    private readonly IBannedUsersService _bannedUsersService;
    private readonly IBanService _banService;
    private readonly IUserService _userService;
    private readonly IUserService _userService2;

    public BanFacade(IUnitOfWorkProvider provider, IUserService userService, IUserService userService2,
        IBanService banService, IBannedUsersService bannedUsersService, IFriendshipService friendshipService) :
        base(provider)
    {
        _userService = userService;
        _userService2 = userService2;
        _banService = banService;
        _bannedUsersService = bannedUsersService;
    }

    public async Task Ban(string banningUser, string userToBeBanned)
    {
        using var uow = UnitOfWorkProvider.Create();
        var bUser = _userService.GetUserByUsername(banningUser);
        var tUser = _userService2.GetUserByUsername(userToBeBanned);
        await _banService.CreateAsync(new BanDto
        {
            BannedId = tUser.Id,
            BannerId = bUser.Id
        });
        await uow.CommitAsync();
    }

    public IList<BanWithUsersDto> BannedUsers(string jwtUsername)
    {
        using var uow = UnitOfWorkProvider.Create();
        var user = _userService.GetUserByUsername(jwtUsername);
        return _bannedUsersService.GetBanned(user.Id);
    }

    public async Task RemoveBan(string jwtUsername, int id)
    {
        using var uow = UnitOfWorkProvider.Create();
        var user = _userService.GetUserByUsername(jwtUsername);
        var ban = await _bannedUsersService.GetAsync(id);
        if (ban is null)
        {
            throw new Exception("no ban with this id");
        }
        if (user.Id != ban.BannerId)
        {
            throw new Exception("Cannot remove ban of another user.");
        }
        await _bannedUsersService.DeleteAsync(id);
        await uow.CommitAsync();
    }
}