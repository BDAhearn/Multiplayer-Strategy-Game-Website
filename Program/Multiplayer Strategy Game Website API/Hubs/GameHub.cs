using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class GameHub : Hub
    {
        public async Task JoinLobby(string lobbyId, string user)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyId);
            await Clients.Group(lobbyId).SendAsync("PlayerJoined", user);
            await Clients.Group(lobbyId).SendAsync("LobbyUpdated");
        }

        public async Task SendMove(string lobbyId, string user, string move)
        {
            await Clients.Group(lobbyId).SendAsync("ReceiveMove", user, move);
        }
    }
}