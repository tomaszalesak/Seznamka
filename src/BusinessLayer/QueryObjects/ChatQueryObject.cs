using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using Domain.Entities;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.QueryObjects;

public class ChatQueryObject : QueryObjectBase<Chat, ChatDto, ChatFilterDto, IQuery<Chat>>
{
    public ChatQueryObject(IQuery<Chat> query) : base(query)
    {
    }
}