using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multiplayer_Strategy_Game_Website_API.Data;
using Multiplayer_Strategy_Game_Website_API.Models;
using System.Security.Claims;

namespace Multiplayer_Strategy_Game_Website_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LobbyController : ControllerBase
    {
        private readonly GameSiteDbContext _context;
        public LobbyController(GameSiteDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetLobbies")]
        public IActionResult Get()
        {
            var lobbies = _context.Lobbies
                .Select(l => new
                {
                    l.lobbyId,

                    gameName = _context.Games
                        .Where(g => g.gameId == l.lobbyGameId)
                        .Select(g => g.gameName)
                        .FirstOrDefault(),

                    hostName = _context.Players
                        .Where(p => p.playerId == l.lobbyHostID)
                        .Select(p => p.playerName)
                        .FirstOrDefault(),

                    challengerName = _context.Players
                        .Where(p => p.playerId == l.lobbyChallengerId)
                        .Select(p => p.playerName)
                        .FirstOrDefault(),

                    l.lobbyStatus,
                    l.lobbyDateCreated,
                    l.lobbyVisibility
                })
                .ToList();

            return Ok(lobbies);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateLobby([FromBody] CreateLobbyRequest request)
        {
            if (request == null)
                return BadRequest("Request is null");

            var userIdClaim =
                User.FindFirst(ClaimTypes.NameIdentifier) ??
                User.FindFirst("sub");

            if (userIdClaim == null)
                return Unauthorized("Missing user id");


            var userId = int.Parse(userIdClaim.Value);

            var lobby = new Lobby
            {
                lobbyGameId = request.lobbyGameId,
                lobbyVisibility = request.lobbyVisibility,
                lobbyHostID = int.Parse(userIdClaim.Value),
                lobbyStatus = "Open",
                lobbyDateCreated = DateTime.UtcNow
            };

            _context.Lobbies.Add(lobby);
            _context.SaveChanges();

            return Ok(new
            {
                lobbyId = lobby.lobbyId,
                role = "host"
            });
        }

        [Authorize]
        [HttpPost("{id}/join")]
        public IActionResult JoinLobby(int id)
        {
            var lobby = _context.Lobbies.FirstOrDefault(l => l.lobbyId == id);

            if (lobby == null)
                return NotFound("Lobby not found");

            if (lobby.lobbyChallengerId != null)
                return BadRequest("Lobby already has a challenger");

            var userIdClaim =
                User.FindFirst(ClaimTypes.NameIdentifier) ??
                User.FindFirst("sub");

            if (userIdClaim == null)
                return Unauthorized();

            var userId = int.Parse(userIdClaim.Value);

            if (lobby.lobbyHostID == userId)
                return BadRequest("You cannot join your own lobby");

            lobby.lobbyChallengerId = userId;
            lobby.lobbyStatus = "InProgress";

            _context.SaveChanges();

            return Ok(new
            {
                lobbyId = lobby.lobbyId,
                role = "challenger"
            });
        }

    }
}
