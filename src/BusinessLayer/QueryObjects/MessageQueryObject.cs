using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using Domain.Entities;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.QueryObjects;

public class MessageQueryObject : QueryObjectBase<Message, MessageDto, MessageFilterDto, IQuery<Message>>
{
    public MessageQueryObject(IQuery<Message> query) : base(query)
    {
    }
}