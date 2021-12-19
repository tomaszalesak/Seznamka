using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using BusinessLayer.QueryObjects;
using BusinessLayer.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.Services.Implementations;

public class ChatService : CrudQueryServiceBase<Chat, ChatDto, ChatFilterDto>, IChatService
{
    public ChatService(IRepository<Chat> repository, QueryObjectBase<Chat, ChatDto, ChatFilterDto, IQuery<Chat>> qob) : base(repository, qob)
    {
    }
}