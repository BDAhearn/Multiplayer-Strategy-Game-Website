using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Multiplayer_Strategy_Game_Website_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    gameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gameStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.gameId);
                });

            migrationBuilder.CreateTable(
                name: "Lobbies",
                columns: table => new
                {
                    lobbyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lobbyGameId = table.Column<int>(type: "int", nullable: false),
                    lobbyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lobbyHostID = table.Column<int>(type: "int", nullable: false),
                    lobbyHostStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lobbyChallengerId = table.Column<int>(type: "int", nullable: true),
                    lobbyChallengerStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lobbyDateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lobbyVisibility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lobbyMovesJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lobbies", x => x.lobbyId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    playerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    playerPasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    playerDateJoined = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.playerId);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "gameId", "gameName", "gameStatus" },
                values: new object[,]
                {
                    { 1, "TicTacToe", "Testing" },
                    { 2, "Connect 4", "Testing" },
                    { 3, "Connect The Dots", "Closed" }
                });

            migrationBuilder.InsertData(
                table: "Lobbies",
                columns: new[] { "lobbyId", "lobbyChallengerId", "lobbyChallengerStatus", "lobbyDateCreated", "lobbyGameId", "lobbyHostID", "lobbyHostStatus", "lobbyMovesJson", "lobbyStatus", "lobbyVisibility" },
                values: new object[,]
                {
                    { 1, 2, "won", new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "lost", "[]", "closed", "public" },
                    { 2, 3, "won", new DateTime(2026, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "lost", "[]", "closed", "private" },
                    { 3, null, null, new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, "[]", "Open", "public" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "playerId", "playerDateJoined", "playerName", "playerPasswordHash" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "techstreet", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=" },
                    { 2, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "progamer97", "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=" },
                    { 3, new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GameSkayer93", "ZehL4zUy+3hMSBKWdfnv86aCsnFowOp0Syz1juAjN8U=" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Lobbies");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
