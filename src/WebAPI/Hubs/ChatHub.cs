using BusinessLayer.Facades.FacadeInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs;

[Authorize]
public class ChatHub : Hub
{
    private static readonly ConnectionMapping<string> Connections = new();
    private readonly IMessageFacade _messageFacade;

    public ChatHub(IMessageFacade messageFacade)
    {
        _messageFacade = messageFacade;
    }

    public async Task SendChatMessage(int chatId, int authorId, string toUsername, string message)
    {
        await _messageFacade.SendMessageAsync(chatId, authorId, message);
        foreach (var connectionId in Connections.GetConnections(toUsername))
        {
            await Clients.Client(connectionId).SendAsync(message);
            await Clients.Caller.SendAsync(message);
        }
    }

    public override Task OnConnectedAsync()
    {
        if (Context.User is { Identity: { } }) Connections.Add(Context.User.Identity.Name, Context.ConnectionId);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        if (Context.User is { Identity: { } }) Connections.Remove(Context.User.Identity.Name, Context.ConnectionId);
        return base.OnDisconnectedAsync(null);
    }
}