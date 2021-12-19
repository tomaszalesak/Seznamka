using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using BusinessLayer.QueryObjects;
using BusinessLayer.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.Services.Implementations;

public class UserChatService : CrudQueryServiceBase<UserChat, UserChatDto, UserChatFilterDto>, IUserChatService
{
    public UserChatService(IRepository<UserChat> repository, QueryObjectBase<UserChat, UserChatDto, UserChatFilterDto, IQuery<UserChat>> qob) : base(repository, qob)
    {
    }
}