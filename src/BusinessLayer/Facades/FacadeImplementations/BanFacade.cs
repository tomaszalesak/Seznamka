using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using BusinessLayer.Services.Interfaces;
using Infrastructure.Persistence.UnitOfWork;

namespace BusinessLayer.Facades.FacadeImplementations;

public class BanFacade : FacadeBase, IBanFacade
{
    private readonly IBanService _banService;
    private readonly IUserService _userService;
    private readonly IUserService _userService2;

    public BanFacade(IUnitOfWorkProvider provider, IUserService userService, IUserService userService2, IBanService banService) :
        base(provider)
    {
        _userService = userService;
        _userService2 = userService2;
        _banService = banService;
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
}