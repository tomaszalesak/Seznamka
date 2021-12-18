using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs;

public class NameUserIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection)
    {
        return connection.User.Identity?.Name;
    }
}