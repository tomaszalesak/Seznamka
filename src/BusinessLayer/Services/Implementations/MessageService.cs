using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using BusinessLayer.QueryObjects;
using BusinessLayer.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.Services.Implementations;

public class MessageService : CrudQueryServiceBase<Message, MessageDto, MessageFilterDto>, IMessageService
{
    public MessageService(IRepository<Message> repository, QueryObjectBase<Message, MessageDto, MessageFilterDto, IQuery<Message>> qob) : base(repository, qob)
    {
    }
}