using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace Multiplayer_Strategy_Game_Website_API.Models
{
    public class Lobby
    {
        public int lobbyId { get; set; }
        public int lobbyGameId { get; set; }
        public string? lobbyStatus { get; set; }
        public int  lobbyHostID { get; set; }
        public string? lobbyHostStatus { get; set; }
        public int? lobbyChallengerId { get; set; }
        public string? lobbyChallengerStatus { get; set; }
        public DateTime lobbyDateCreated { get; set; }
        public string lobbyVisibility { get; set; }
        public string lobbyMovesJson { get; set; } = "[]";

        public Lobby() { }

        public Lobby(int _id, int _game, int _host, string _visibility, DateTime _date)
        {
            lobbyId = _id;
            lobbyGameId = _game;
            lobbyHostID = _host;
            lobbyVisibility = _visibility;
            lobbyDateCreated = _date;
        }

        [NotMapped]
        public List<string> lobbyMoves
        {
            get =>
                string.IsNullOrWhiteSpace(lobbyMovesJson)
                    ? new List<string>()
                    : System.Text.Json.JsonSerializer.Deserialize<List<string>>(lobbyMovesJson)
                      ?? new List<string>();

            set =>
                lobbyMovesJson = System.Text.Json.JsonSerializer.Serialize(value ?? new List<string>());
        }
    }
}
