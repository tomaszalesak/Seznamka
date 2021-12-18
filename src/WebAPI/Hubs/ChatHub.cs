using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs;

[Authorize]
public class ChatHub : Hub
{
    private static readonly ConnectionMapping<string> Connections = new();
    
    public void SendChatMessage(string who, string message)
    {
        foreach (var connectionId in Connections.GetConnections(who))
        {
            Clients.Client(connectionId).SendAsync(message);
            Clients.Caller.SendAsync(message);
        }
    }

    public override Task OnConnectedAsync()
    {
        var name = Context.UserIdentifier;
        Connections.Add(name, Context.ConnectionId);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        var name = Context.UserIdentifier;
        Connections.Remove(name, Context.ConnectionId);
        return base.OnDisconnectedAsync(null);
    }
}