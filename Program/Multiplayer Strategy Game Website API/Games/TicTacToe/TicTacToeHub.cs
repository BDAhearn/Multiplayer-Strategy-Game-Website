using Microsoft.AspNetCore.SignalR;
using Multiplayer_Strategy_Game_Website_API.Data;
using Multiplayer_Strategy_Game_Website_API.Games.TicTacToe;
using Microsoft.EntityFrameworkCore;

namespace Multiplayer_Strategy_Game_Website_API.Games.TicTacToe
{
    public class TicTacToeHub : Hub
    {
        private readonly GameSiteDbContext _context;
        private readonly TicTacToeEngine _engine;

        public TicTacToeHub(GameSiteDbContext context)
        {
            _context = context;
            _engine = new TicTacToeEngine();
        }

        public async Task JoinLobby(string lobbyId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyId);

            var lobby = await _context.Lobbies
                .FirstOrDefaultAsync(l => l.lobbyId.ToString() == lobbyId);

            if (lobby == null) return;

            var moves = System.Text.Json.JsonSerializer.Deserialize<List<string>>(lobby.lobbyMovesJson) ?? new List<string>();
            var board = _engine.BuildBoard(moves);
            var winner = _engine.CheckWinner(board);
            var currentTurn = moves.Count % 2 == 0 ? "X" : "O";

        }

        public async Task MakeMove(string lobbyId, int index)
        {
            var lobby = _context.Lobbies.FirstOrDefault(l => l.lobbyId.ToString() == lobbyId);

            if (lobby == null) return;
            if (lobby.lobbyGameId != 1) return;

            var moves = System.Text.Json.JsonSerializer.Deserialize<List<string>>(lobby.lobbyMovesJson) ?? new List<string>();

            if (!_engine.IsValidMove(moves, index))
                return;

            moves.Add(index.ToString());
            lobby.lobbyMoves = moves;

            _context.SaveChanges();

            var board = _engine.BuildBoard(moves);
            var winner = _engine.CheckWinner(board);
            var currentTurn = _engine.GetCurrentTurn(moves);

            if (winner != null)
            {
                lobby.lobbyStatus = "Closed";
                currentTurn = null;
                if (winner == "X")
                {
                    lobby.lobbyHostStatus = "Won";
                    lobby.lobbyChallengerStatus = "Lost";
                }

                else if (winner == "O")
                {
                    lobby.lobbyHostStatus = "Lost";
                    lobby.lobbyChallengerStatus = "Won";
                }
                else if (winner == "Draw")
                {
                    lobby.lobbyHostStatus = "Draw";
                    lobby.lobbyChallengerStatus = "Draw";
                }

                _context.SaveChanges();
            }

            await Clients.Group(lobbyId).SendAsync("GameUpdated", new
            {
                board,
                currentTurn,
                winner,
                moves
            });

            await Clients.Group(lobbyId).SendAsync("GameUpdated", new
            {
                board,
                currentTurn,
                winner,
                moves
            });
        }
    }
}