using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using BusinessLayer.QueryObjects;
using BusinessLayer.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.Services.Implementations;

public class FriendshipService : CrudQueryServiceBase<Friendship, FriendshipDto, FriendshipFilterDto>,
    IFriendshipService
{
    public FriendshipService(IRepository<Friendship> repository,
        QueryObjectBase<Friendship, FriendshipDto, FriendshipFilterDto, IQuery<Friendship>> qob) : base(repository, qob)
    {
    }
}