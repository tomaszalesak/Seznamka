namespace BusinessLayer.Facades.FacadeInterfaces;

public interface IMessageFacade : IDisposable
{
    Task SendMessageAsync(int chatId, int authorId, string message);
}