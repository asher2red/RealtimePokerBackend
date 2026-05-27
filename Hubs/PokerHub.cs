using Microsoft.AspNetCore.SignalR;

namespace RealtimePokerBackend.Hubs;

public class PokerHub : Hub
{
    public async Task JoinRoom(string roomName, string username)
    {
        await Groups.AddToGroupAsync(
            Context.ConnectionId,
            roomName);

        await Clients.Group(roomName)
            .SendAsync(
                "ReceiveMessage",
                $"{username} joined {roomName}");
    }

    public async Task SendMessage(
        string roomName,
        string username,
        string message)
    {
        await Clients.Group(roomName)
            .SendAsync(
                "ReceiveMessage",
                $"{username}: {message}");
    }

    public async Task LeaveRoom(
        string roomName,
        string username)
    {
        await Groups.RemoveFromGroupAsync(
            Context.ConnectionId,
            roomName);

        await Clients.Group(roomName)
            .SendAsync(
                "ReceiveMessage",
                $"{username} left {roomName}");
    }
}