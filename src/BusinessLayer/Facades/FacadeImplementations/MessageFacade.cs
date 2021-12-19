using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using BusinessLayer.Services.Interfaces;
using Infrastructure.Persistence.UnitOfWork;

namespace BusinessLayer.Facades.FacadeImplementations;

public class MessageFacade : FacadeBase, IMessageFacade
{
    private readonly IMessageService _messageService;

    public MessageFacade(IUnitOfWorkProvider provider, IMessageService messageService) : base(provider)
    {
        _messageService = messageService;
    }

    public async Task SendMessageAsync(int chatId, int authorId, string message)
    {
        using var uow = UnitOfWorkProvider.Create();
        await _messageService.CreateAsync(new MessageDto
        {
            AuthorId = authorId,
            ChatId = chatId,
            Text = message,
            SendTime = DateTime.UtcNow
        });
    }
}